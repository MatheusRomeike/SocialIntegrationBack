using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company
{
    public class Company : BaseEntity
    {
        public Company() { }


        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User.User> Users { get; set; }
        public virtual ICollection<Image.Image> Images { get; set; }
    }
}
