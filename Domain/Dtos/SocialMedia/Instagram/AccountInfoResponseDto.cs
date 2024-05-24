using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.SocialMedia.Instagram
{
    public class AccountInfoResponseDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_picture_url")]
        public string ProfilePictureUrl { get; set; }
    }
}
