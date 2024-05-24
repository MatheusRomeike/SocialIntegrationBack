using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Dtos.SocialMedia.Instagram
{
    public class BusinessAccountResponseDto
    {
        [JsonProperty("data")]
        public List<BusinessAccountDto> Data { get; set; }
    }
}
