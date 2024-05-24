using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.SocialMedia.Instagram
{
    public class BusinessAccountDto
    {
        [JsonProperty("instagram_business_account")]
        public InstagramBusinessAccountDto InstagramBusinessAccount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
