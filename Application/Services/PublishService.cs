using Application.Interfaces;
using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using Newtonsoft.Json;
using Application.ViewModels;

namespace Application.Services
{
    public class PublishService : IPublishService
    {
        #region Atributos
        private readonly HttpClient _httpClient;
        #endregion

        #region Construtor
        public PublishService()
        {
            _httpClient = new HttpClient();
        }
        #endregion

        #region Métodos

        public async Task<bool> PublishAsync(PublishViewModel model)
        {
            if (model.X)
                await PublishTwitterAsync(model.Text);
            return true;
        }

        private async Task<bool> PublishTwitterAsync(string tweetText)
        {
            var options = new RestClientOptions();

            var oAuth1 = OAuth1Authenticator.ForAccessToken(
                            consumerKey: "EOO7UjWUEmHInrbvCzX28rZWK",
                            consumerSecret: "8UBpIQy4TVcwpRqtUoxijBMLr9r7SfEQ9QnvzDbwNdugV0JYE5",
                            token: "1386177872142942213-c7fRpoBjn7Gy96jXc3s5FRbGapibpu",
                            tokenSecret: "Mi7SFkho0myZZsYyzzN6TSIplEDt4vQLKAG5ssf8frEZA",
                            OAuthSignatureMethod.HmacSha1);

            options.Authenticator = oAuth1;

            var client = new RestClient(options);

            var request = new RestRequest("https://api.twitter.com/2/tweets", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { text = tweetText }), ParameterType.RequestBody);

            var response = client.Execute(request);

            return true;
        }

        #endregion
    }
}
