using Application.Interfaces.ServiceInterfaces;
using Application.ViewModels;
using Data.Configuration;
using Data.Contracts;
using Data.Interfaces.RepositoryInterface;
using Data.Repository;
using Domain.Entities.Post;
using Domain.Entities.SocialMedia;
using Domain.Entities.SocialMedia.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IEnumerable<ISocialMediaIntegrationService> _socialMediaServices;
        private readonly IPostRepository _postRepository;

        public SocialMediaService(
            ISocialMediaRepository socialMediaRepository,
            IAccountRepository accountRepository,
            IEnumerable<ISocialMediaIntegrationService> socialMediaServices,
            IPostRepository postRepository,
            IUnitOfWork unitOfWork)
        {
            _socialMediaRepository = socialMediaRepository;
            _accountRepository = accountRepository;
            _socialMediaServices = socialMediaServices;
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SocialMedia>> SocialMedias()
        {
            return await _socialMediaRepository.GetAllAsync(
                    include: i => i.Include(x => x.SocialMediaConfiguration)
                );
        }

        public async Task<bool> PublishAsync(PublishViewModel model, long userId)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var accounts = await _accountRepository.GetAllAsync(
                                        include: i => i.Include(x => x.AccountConfiguration),
                                        predicate: p => model.SocialMediaTypes.Contains((SocialMediaType)p.SocialMediaId) && p.UserId == userId);

                    var socialMedias = await _socialMediaRepository.GetAllAsync(
                                        include: i => i.Include(x => x.SocialMediaConfiguration),
                                        predicate: p => model.SocialMediaTypes.Contains((SocialMediaType)p.Id));

                    var socialMediaService = _socialMediaServices.Where(p => model.SocialMediaTypes.Contains(p.SocialMediaType));

                    List<Post> posts = new List<Post>();

                    foreach (var service in socialMediaService)
                    {
                        posts.AddRange(await service.PublishAsync(model, accounts.Where(x => (SocialMediaType)x.SocialMediaId == service.SocialMediaType), socialMedias.First(x => (SocialMediaType)x.Id == service.SocialMediaType)));
                    }

                    await _postRepository.AddAsync(posts);

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
