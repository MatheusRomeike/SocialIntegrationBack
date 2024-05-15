using Data.Contracts;
using Domain.Entities.Account;
using Domain.Entities.Post;
using Domain.Entities.SocialNetwork.Enums;
using Application.Interfaces.ServiceInterfaces;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth;
using RestSharp.Authenticators;
using RestSharp;
using Domain.Entities.SocialNetwork;
using Domain.Dtos.X;


namespace Application.SocialNetworks
{
    public class XService : ISocialNetworkPublishService
    {
        public SocialNetworkType SocialNetworkType => SocialNetworkType.X;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRestClientService _restClient;

        public XService(
            IUnitOfWork unitOfWork,
            IRestClientService restClient)
        {
            _unitOfWork = unitOfWork;
            _restClient = restClient;
        }

        public async Task<List<Post>> PublishAsync(string content, SocialNetwork socialNetwork, IEnumerable<Account> accounts)
        {
            var posts = new List<Post>();
            foreach (var account in accounts)
            {
                var client = _restClient.CreateRestClient(await AuthenticateAsync(account));

                //https://api.twitter.com/2
                var request = new RestRequest($"{socialNetwork.BaseUrlApi}/tweets", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(
                    new
                    {
                        text = content
                    }), ParameterType.RequestBody);

                var response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var postResponse = JsonConvert.DeserializeObject<XPostResponseDto>(response.Content);
                    posts.Add(new Post()
                    {
                        AccountId = account.Id,
                        SocialNetworkPostId = Convert.ToInt64(postResponse.data.id),
                    });
                }
            }

            return posts;
        }

        public async Task<IAuthenticator> AuthenticateAsync(Account account)
        {
            return OAuth1Authenticator.ForAccessToken(
                consumerKey: account.ConsumerKey,
                consumerSecret: account.ConsumerSecret,
                token: account.Token,
                tokenSecret: account.TokenSecret,
                OAuthSignatureMethod.HmacSha1);
        }
    }
}
