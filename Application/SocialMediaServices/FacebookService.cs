using Data.Contracts;
using Domain.Entities.Account;
using Domain.Entities.Post;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities.SocialMedia.Enums;
using Domain.Entities.SocialMedia;
using Domain.Dtos.SocialMedia.Instagram;
using Utils;
using Application.ViewModels;
using Domain.Dtos.SocialMedia.Facebook;

namespace Application.SocialMediaService
{
    public class FacebookService : ISocialMediaIntegrationService
    {
        public SocialMediaType SocialMediaType => SocialMediaType.Facebook;

        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpRequest _httpRequest;

        public FacebookService(IUnitOfWork unitOfWork)
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
            account.AccountConfiguration.TokenExpirationDate = DateTime.Now.AddSeconds(accessToken.ExpiresIn);
            account.AccountConfiguration.TokenType = accessToken.TokenType == "bearer" ? "Bearer" : accessToken.TokenType;

            var accountInfo = await GetAccountAsync(account.AccountConfiguration, socialMediaConfiguration);

            account.AccountConfiguration.AccessToken = accountInfo.AccessToken;
            account.AccountConfiguration.RefreshToken = accountInfo.AccessToken;

            account.SocialMediaAccountId = Convert.ToInt64(accountInfo.Id);
            account.Name = accountInfo.Name;
            account.SocialMediaId = socialMediaConfiguration.Id;

            return account;
        }

        public async Task<List<Post>> PublishAsync(PublishViewModel model, IEnumerable<Account> accounts, SocialMedia socialMedia)
        {
            var posts = new List<Post>();
            foreach (var account in accounts)
            {
                var url = $"{socialMedia.SocialMediaConfiguration.BaseUrl}/{account.SocialMediaAccountId}/feed";
                var headers = new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {account.AccountConfiguration.AccessToken}" },

                };

                var data = new
                {
                    message = model.Text,
                    published = "true"
                };

                var response = await _httpRequest.SendAsync<PostResponseDto>(url, HttpMethod.Post, data, headers: headers);

                posts.Add(new Post()
                {
                    AccountId = account.Id,
                    SocialMediaPostId = response.Id,
                    SocialMediaId = socialMedia.SocialMediaConfiguration.Id,
                    Text = model.Text,
                    ImageQuantity = 1
                });
            }
            return posts;
        }

        private async Task<AccessTokenResponseDto> GetAccessToken(string code, SocialMediaConfiguration socialMediaConfiguration)
        {
            string url = $"{socialMediaConfiguration.BaseUrl}/oauth/access_token";
            var data = new Dictionary<string, string>
            {
                { "client_id", socialMediaConfiguration.ClientId },
                { "client_secret", socialMediaConfiguration.ClientSecret },
                { "code", code },
                { "redirect_uri", socialMediaConfiguration.RedirectUri }
            };

            return await _httpRequest.SendAsync<AccessTokenResponseDto>(url, HttpMethod.Post, data, contentType: "application/x-www-form-urlencoded");
        }

        private async Task<AccountInfoDataDto> GetAccountAsync(AccountConfiguration accountConfiguration, SocialMediaConfiguration socialMediaConfiguration)
        {
            var account = new Account();
            string url = $"{socialMediaConfiguration.BaseUrl}/me/accounts?fields=id,name,picture,access_token";
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"{accountConfiguration.TokenType} {accountConfiguration.AccessToken}" }
            };
            var response = await _httpRequest.SendAsync<Domain.Dtos.SocialMedia.Facebook.AccountInfoResponseDto>(url, HttpMethod.Get, headers: headers);

            return response.Data.FirstOrDefault();
        }
    }
}
