using Data.Contracts;
using Domain.Entities.Account;
using Domain.Entities.Post;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities.SocialMedia.Enums;


namespace Application.SocialMediaService
{
    public class XService : IPublishService
    {
        public SocialMediaType SocialMediaType => SocialMediaType.X;

        private readonly IUnitOfWork _unitOfWork;

        public XService(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
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
