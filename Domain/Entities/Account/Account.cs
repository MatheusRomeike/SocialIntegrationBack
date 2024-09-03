using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account
{
    public class Account : BaseEntity
    {
        public long SocialMediaAccountId { get; set; }
        public long SocialMediaId { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }

        public virtual AccountConfiguration AccountConfiguration { get; set; }
        public virtual User.User User { get; set; }
        public virtual SocialMedia.SocialMedia SocialMedia { get; set; }
        public virtual ICollection<Post.Post> Posts { get; set; }
    }
}
