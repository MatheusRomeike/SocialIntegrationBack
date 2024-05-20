

using Domain.Entities.Account;
using Domain.Entities.Post;
using Domain.Entities.SocialMedia.Enums;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IPublishService
    {
        public SocialMediaType SocialMediaType { get; }

        Task<List<Post>> PublishAsync(string postId, string text, IEnumerable<Account> accounts);
    }
}
