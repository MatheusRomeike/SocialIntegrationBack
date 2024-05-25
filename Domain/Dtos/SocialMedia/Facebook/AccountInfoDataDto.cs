using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.SocialMedia.Facebook
{
    public class AccountInfoDataDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public PictureDto Picture { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
