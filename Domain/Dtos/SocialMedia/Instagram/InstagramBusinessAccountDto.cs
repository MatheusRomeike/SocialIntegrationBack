using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.SocialMedia.Instagram
{
    public class InstagramBusinessAccountDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
