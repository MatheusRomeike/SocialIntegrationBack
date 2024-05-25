using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.SocialMedia.X
{
    public class PostDataDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
