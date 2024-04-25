using RestSharp.Authenticators;
using RestSharp;
using Application.Interfaces.ServiceInterfaces;

namespace Application.Services
{
    public class RestClientService : IRestClientService
    {
        public RestClient CreateRestClient(IAuthenticator authenticator)
        {
            var options = new RestClientOptions { Authenticator = authenticator };
            return new RestClient(options);
        }
    }
}
