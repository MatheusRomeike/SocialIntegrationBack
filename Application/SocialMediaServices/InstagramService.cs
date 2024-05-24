using Data.Contracts;
using Domain.Entities.Account;
using Domain.Entities.Post;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities.SocialMedia.Enums;
using Domain.Entities.SocialMedia;
using Data.Interfaces.RepositoryInterface;
using RestSharp;
using System.Text;
using Domain.Dtos.SocialMedia.Instagram;
using System.Text.Json;
using Azure.Core;
using Utils;
using Newtonsoft.Json;


namespace Application.SocialMediaService
{
    public class InstagramService : ISocialMediaIntegrationService
    {
        public SocialMediaType SocialMediaType => SocialMediaType.Instagram;

        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpRequest _httpRequest;

        public InstagramService(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            _httpRequest = new HttpRequest();
        }

        public async Task<Account> AuthenticateAsync(string code, SocialMediaConfiguration socialMediaConfiguration)
        {
            Account account = new Account()
            {
                AccountConfiguration = new AccountConfiguration() { }
            };

            AccessTokenResponseDto accessToken = await GetAccessToken(code, socialMediaConfiguration);

            account.AccountConfiguration.AccessToken = accessToken.AccessToken;
            account.AccountConfiguration.RefreshToken = accessToken.AccessToken;
            account.AccountConfiguration.TokenExpirationDate = DateTime.Now.AddSeconds(accessToken.ExpiresIn);
            account.AccountConfiguration.TokenType = accessToken.TokenType == "bearer" ? "Bearer" : accessToken.TokenType;

            var accountInfo = await GetAccountAsync(account.AccountConfiguration, socialMediaConfiguration);

            account.SocialMediaAccountId = Convert.ToInt64(accountInfo.Id);
            account.Name = accountInfo.Name;
            account.ProfilePicture = await _httpRequest.DownloadImageAsync(accountInfo.ProfilePictureUrl);
            account.SocialMediaId = socialMediaConfiguration.Id;

            return account;

        }

        public async Task<List<Post>> PublishAsync(string postId, string text, IEnumerable<Account> accounts)
        {
            var posts = new List<Post>();
            foreach (var account in accounts)
            {

            }

            return posts;
        }

        private async Task<AccessTokenResponseDto> GetAccessToken(string code, SocialMediaConfiguration socialMediaConfiguration)
        {
            string url = $"{socialMediaConfiguration.BaseUrl}/oauth/access_token" +
             $"?client_id={socialMediaConfiguration.ClientId}" +
             $"&client_secret={socialMediaConfiguration.ClientSecret}" +
             $"&code={code}" +
             $"&redirect_uri={socialMediaConfiguration.RedirectUri}";
            return await _httpRequest.GetAsync<AccessTokenResponseDto>(url);
        }


        private async Task<AccountInfoResponseDto> GetAccountAsync(AccountConfiguration accountConfiguration, SocialMediaConfiguration socialMediaConfiguration)
        {
            var account = new Account();
            string url = $"{socialMediaConfiguration.BaseUrl}/me/accounts?fields=instagram_business_account&access_token={accountConfiguration.AccessToken}";
            var response = await _httpRequest.GetAsync<BusinessAccountResponseDto>(url);

            var id = response.Data.FirstOrDefault(x => x.InstagramBusinessAccount != null)?.InstagramBusinessAccount?.Id;

            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"{accountConfiguration.TokenType} {accountConfiguration.AccessToken}" },
            };
            url = $"{socialMediaConfiguration.BaseUrl}/{id}?fields=id,name,profile_picture_url";
            var accountInfo = await _httpRequest.GetAsync<AccountInfoResponseDto>(url, headers: headers);

            return accountInfo;
        }
    }
}
