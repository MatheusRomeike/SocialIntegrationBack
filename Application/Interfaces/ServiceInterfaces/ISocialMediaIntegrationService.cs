

using Domain.Entities.Account;
using Domain.Entities.Post;
using Domain.Entities.SocialMedia;
using Domain.Entities.SocialMedia.Enums;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface ISocialMediaIntegrationService
    {
        public SocialMediaType SocialMediaType { get; }

        Task<Account> AuthenticateAsync(string code, SocialMediaConfiguration socialMediaConfiguration);
        Task<List<Post>> PublishAsync(string postId, string text, IEnumerable<Account> accounts);
    }
}
