using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SocialMedia
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual SocialMediaConfiguration SocialMediaConfiguration { get; set; }
        public virtual ICollection<PostType> PostTypes { get; set; }
    }
}
