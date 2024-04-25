using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PostImage
{
    public class PostImage : BaseEntity
    {
        public PostImage() { }


        public int Order { get; set; }


        public long PostId { get; set; }
        public Post.Post Post { get; set; }

        public long ImageId { get; set; }
        public Image.Image Image { get; set; }

    }
}
