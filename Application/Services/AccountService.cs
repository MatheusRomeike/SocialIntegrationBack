using Application.Interfaces.ServiceInterfaces;
using Data.Contracts;
using Data.Interfaces.RepositoryInterface;
using Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public AccountService(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
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
    }
}
