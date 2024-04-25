

using Domain.Entities.Account;
using Domain.Entities.Post;
using Domain.Entities.PostGroup;
using Domain.Entities.SocialNetwork;
using Domain.Entities.SocialNetwork.Enums;
using RestSharp.Authenticators;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface ISocialNetworkService
    {
        public SocialNetworkType SocialNetworkType { get; }

        Task<List<Post>> PublishAsync(string content, SocialNetwork socialNetwork, IEnumerable<Account> accounts);
        Task<IAuthenticator> AuthenticateAsync(Account account);
    }
}
