using Application.ViewModels;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities.PostGroup;
using Domain.Entities.SocialNetwork.Enums;
using Domain.Entities.Post;
using Data.Interfaces.RepositoryInterface;

namespace Application.Services
{
    public class PublishService : IPublishService
    {
        private readonly IEnumerable<ISocialNetworkService> _socialNetworkServices;
        private readonly IPostGroupRepository _postGroupRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ISocialNetworkRepository _socialNetworkRepository;

        public PublishService(
            IEnumerable<ISocialNetworkService> socialNetworkServices,
            IPostGroupRepository postGroupRepository,
            IAccountRepository accountRepository,
            ISocialNetworkRepository socialNetworkRepository)
        {
            _socialNetworkServices = socialNetworkServices;
            _postGroupRepository = postGroupRepository;
            _accountRepository = accountRepository;
            _socialNetworkRepository = socialNetworkRepository;
        }


        public async Task<bool> PublishAsync(PublishViewModel model, long userId)
        {
            var accounts = await _accountRepository.GetAllAsync(
                predicate: p => model.SocialNetworkTypes.Contains((SocialNetworkType)p.SocialNetworkId));

            var socialNetworks = await _socialNetworkRepository.GetAllAsync(
                               predicate: p => model.SocialNetworkTypes.Contains((SocialNetworkType)p.Id));

            var socialNetworkService = GetSocialNetworkServices(model.SocialNetworkTypes);

            List<Post> posts = new List<Post>();

            foreach (var service in socialNetworkService)
            {
                posts.AddRange(await service.PublishAsync(model.Content, socialNetworks.First(x => (SocialNetworkType)x.Id == service.SocialNetworkType), accounts));
            }

            var postGroup = new PostGroup()
            {
                Name = model.PostGroupTitle,
                Description = model.PostGroupDescription,
                Content = model.Content,
                UserId = userId,
                Posts = posts
            };

            return true;
        }

        public IEnumerable<ISocialNetworkService> GetSocialNetworkServices(List<SocialNetworkType> socialNetworkTypes)
        {
            var compatibleServices = _socialNetworkServices
                .Where(service => socialNetworkTypes.Contains(service.SocialNetworkType))
                .ToList();

            return compatibleServices;
        }

    }
}
