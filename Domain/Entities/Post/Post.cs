
using Domain.Entities.Account;
using Domain.Entities.Core;

namespace Domain.Entities.Post
{
    public class Post : BaseEntity
    {
        public Post() { }

        public long SocialNetworkPostId { get; set; }

        public long PostGroupId { get; set; }
        public PostGroup.PostGroup PostGroup { get; set; }

        public long AccountId { get; set; }
        public Account.Account Account { get; set; }

        public virtual ICollection<PostImage.PostImage> PostImages { get; set; }
    }
}
