using Data.Contracts;
using Domain.Entities.Account;
using Domain.Entities.Post;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities.SocialMedia.Enums;
using Domain.Entities.SocialMedia;


namespace Application.SocialMediaService
{
    public class XService : ISocialMediaIntegrationService
    {
        public SocialMediaType SocialMediaType => SocialMediaType.X;

        private readonly IUnitOfWork _unitOfWork;

        public XService(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Account> AuthenticateAsync(string code, SocialMediaConfiguration socialMediaConfiguration)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> PublishAsync(string postId, string text, IEnumerable<Account> accounts)
        {
            var posts = new List<Post>();
            foreach (var account in accounts)
            {

            }

            return posts;
        }

    }
}
