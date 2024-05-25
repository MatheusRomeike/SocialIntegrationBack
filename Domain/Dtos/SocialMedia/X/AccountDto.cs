using Newtonsoft.Json;

namespace Domain.Dtos.SocialMedia.X
{
    public class AccountDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
    }
}
