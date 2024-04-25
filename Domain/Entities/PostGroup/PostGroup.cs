using Domain.Entities.Company;
using Domain.Entities.Core;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PostGroup
{
    public class PostGroup : BaseEntity
    {
        public PostGroup() { }


        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }


        public long UserId { get; set; }
        public User.User User { get; set; }

        public virtual ICollection<Post.Post> Posts { get; set; }
    }
}
