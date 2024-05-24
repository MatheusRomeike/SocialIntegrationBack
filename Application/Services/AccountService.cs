using Application.Interfaces.ServiceInterfaces;
using Data.Contracts;
using Data.Interfaces.RepositoryInterface;
using Data.Repository;
using Domain.Entities.Account;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IEnumerable<ISocialMediaIntegrationService> _socialMediaServices;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountConfigurationRepository _accountConfigurationRepository;
        private readonly ISocialMediaConfigurationRepository _socialMediaConfigurationRepository;
        private readonly ISocialMediaRepository _socialMediaRepository;

        public AccountService(
            IAccountRepository accountRepository,
            IAccountConfigurationRepository accountConfigurationRepository,
            IUnitOfWork unitOfWork,
            IEnumerable<ISocialMediaIntegrationService> socialMediaServices,
            ISocialMediaConfigurationRepository socialMediaConfigurationRepository,
            ISocialMediaRepository socialMediaRepository)
        {
            _accountRepository = accountRepository;
            _accountConfigurationRepository = accountConfigurationRepository;
            _unitOfWork = unitOfWork;
            _socialMediaServices = socialMediaServices;
            _socialMediaConfigurationRepository = socialMediaConfigurationRepository;
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<IEnumerable<Account>> Accounts(long userId)
        {
            return await _accountRepository.GetAllAsync(
                                   predicate: p => p.UserId == userId,
                                   selector: s => new Account()
                                   {
                                       Name = s.Name,
                                       ProfilePicture = s.ProfilePicture,
                                       SocialMediaId = s.SocialMediaId,
                                   });
        }

        public async Task<bool> AuthenticateAsync(string code, string socialMediaName, long userId)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var socialMediaConfiguration = await _socialMediaConfigurationRepository.GetOneAsync(include: i => i.Include(x => x.SocialMedia), predicate: p => p.SocialMedia.Name.ToLower() == socialMediaName);
                    var socialMediaService = _socialMediaServices.Where(p => (int)p.SocialMediaType == socialMediaConfiguration.Id).First();

                    if (_accountRepository.GetOneAsync(predicate: p => p.UserId == userId && p.SocialMediaId == socialMediaConfiguration.Id) != null)
                    {
                        return false;
                    }

                    var account = await socialMediaService.AuthenticateAsync(code, socialMediaConfiguration);
                    account.UserId = userId;

                    await _accountRepository.AddAsync(account);
                    await _accountConfigurationRepository.AddAsync(account.AccountConfiguration);

                    await _unitOfWork.CommitAsync();
                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        public async Task<bool> DisconnectAccountAsync(string socialMediaName, long userId)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var socialMedia = await _socialMediaRepository.GetOneAsync(predicate: p => p.Name.ToLower() == socialMediaName.ToLower());

                    var account = await _accountRepository.GetOneAsync(include: i => i.Include(x => x.AccountConfiguration), predicate: p => p.SocialMediaId == socialMedia.Id && p.UserId == userId);

                    _accountRepository.Delete(account);
                    _accountConfigurationRepository.Delete(account.AccountConfiguration);

                    await _unitOfWork.CommitAsync();
                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

    }
}
