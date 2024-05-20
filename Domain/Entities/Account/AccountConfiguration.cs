using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account
{
    public class AccountConfiguration : BaseEntity
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public virtual Account Account { get; set; }
    }
}
