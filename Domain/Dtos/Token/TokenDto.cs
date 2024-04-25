using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Token
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
    }
}
