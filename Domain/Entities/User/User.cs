using Domain.Entities.Core;
using Domain.Entities.User.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class User : BaseEntity
    {
        public User() { }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public long CompanyId { get; set; }
        public Company.Company Company { get; set; }

        public virtual ICollection<PostGroup.PostGroup> PostGroups { get; set; }
        public virtual ICollection<Account.Account> Accounts { get; set; }
    }
}
