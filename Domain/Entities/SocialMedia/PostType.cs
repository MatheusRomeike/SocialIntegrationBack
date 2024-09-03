using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SocialMedia
{
    public class PostType : BaseEntity
    {
        public long SocialMediaId { get; set; }
        public string Name { get; set; }
        public int MaxCharacters { get; set; }
        public ICollection<string> AcceptedMediaTypes { get; set; }
        public string MediaAspectRatio { get; set; }

        public virtual SocialMedia SocialMedia { get; set; }
    }
}
