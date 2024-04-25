using Domain.Entities.Core;
using Domain.Entities.PostGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Account
{
    public class Account : BaseEntity
    {
        public Account() { }


        public string Name { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }


        public long UserId { get; set; }
        public virtual User.User User { get; set; }

        public long SocialNetworkId { get; set; }
        public virtual SocialNetwork.SocialNetwork SocialNetwork { get; set; }

        public virtual ICollection<Post.Post> Posts { get; set; }
    }
}
