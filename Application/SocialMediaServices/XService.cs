using Data.Contracts;
using Domain.Entities.Account;
using Domain.Entities.Post;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities.SocialMedia.Enums;
using Domain.Entities.SocialMedia;
using Utils;
using System.Text;
using Domain.Dtos.SocialMedia.X;
using Newtonsoft.Json;
using RestSharp;
using Application.ViewModels;


namespace Application.SocialMediaService
{
    public class XService : ISocialMediaIntegrationService
    {
        public SocialMediaType SocialMediaType => SocialMediaType.X;

        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpRequest _httpRequest;

        public XService(
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
                AccountConfiguration = new AccountConfiguration()
            };

            var accessToken = await GetAccessToken(code, socialMediaConfiguration);
            account.AccountConfiguration.AccessToken = accessToken.AccessToken;
            account.AccountConfiguration.RefreshToken = accessToken.AccessToken;
            account.AccountConfiguration.TokenExpirationDate = DateTime.Now.AddSeconds(accessToken.ExpiresIn);
            account.AccountConfiguration.TokenType = accessToken.TokenType == "bearer" ? "Bearer" : accessToken.TokenType;

            var accountInfo = await GetAccountAsync(account.AccountConfiguration, socialMediaConfiguration);

            account.SocialMediaAccountId = Convert.ToInt64(accountInfo.Id);
            account.Name = accountInfo.Name;
            account.ProfilePicture = await _httpRequest.SendForBytesAsync(accountInfo.ProfileImageUrl.Replace("_normal", ""), HttpMethod.Get);
            account.SocialMediaId = socialMediaConfiguration.Id;


            return account;
        }

        public async Task<List<Post>> PublishAsync(PublishViewModel model, IEnumerable<Account> accounts, SocialMedia socialMedia)
        {
            var posts = new List<Post>();

            foreach (var account in accounts)
            {
                var url = $"{socialMedia.SocialMediaConfiguration.BaseUrl}/2/tweets";
                var headers = new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {account.AccountConfiguration.AccessToken}" },

                };

                var data = new
                {
                    text = model.Text,
                    media = new
                    {
                        media_ids = new[] { "1791894335090294784" }
                    }
                };

                var response = await _httpRequest.SendAsync<PostResponseDto>(url, HttpMethod.Post, data, headers: headers);

                posts.Add(new Post()
                {
                    AccountId = account.Id,
                    SocialMediaPostId = Convert.ToInt64(response.Data.Id),
                    SocialMediaId = socialMedia.SocialMediaConfiguration.Id,
                    Text = model.Text,
                    ImageQuantity = 1
                });
            }

            return posts;
        }


        private async Task<AccessTokenResponseDto> GetAccessToken(string code, SocialMediaConfiguration socialMediaConfiguration)
        {
            string credentials = $"{socialMediaConfiguration.ClientId}:{socialMediaConfiguration.ClientSecret}";
            string encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            string url = $"{socialMediaConfiguration.BaseUrl}/2/oauth2/token";
            var data = new Dictionary<string, string>
            {
                { "code", code },
                { "grant_type", socialMediaConfiguration.GrantType },
                { "client_id", socialMediaConfiguration.ClientId },
                { "redirect_uri", socialMediaConfiguration.RedirectUri },
                { "code_verifier", "challenge" }
            };

            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Basic {encodedCredentials}" },
            };

            return await _httpRequest.SendAsync<Domain.Dtos.SocialMedia.X.AccessTokenResponseDto>(url, HttpMethod.Post, data, contentType: "application/x-www-form-urlencoded", headers: headers);
        }

        private async Task<AccountDto> GetAccountAsync(AccountConfiguration accountConfiguration, SocialMediaConfiguration socialMediaConfiguration)
        {
            var account = new Account();
            string url = $"{socialMediaConfiguration.BaseUrl}/2/users/me?user.fields=id,name,profile_image_url";
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"{accountConfiguration.TokenType} {accountConfiguration.AccessToken}" }
            };
            var response = await _httpRequest.SendAsync<AccountInfoResponseDto>(url, HttpMethod.Get, headers: headers);

            return response.Data;
        }

    }
}
