using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Post
{
    public class Post : BaseEntity
    {
        public long AccountId { get; set; }
        public long SocialMediaPostId { get; set; }
        public long SocialMediaId { get; set; }
        public string Text { get; set; }
        public int ImageQuantity { get; set; }

        public virtual Account.Account Account { get; set; }
    }
}
