using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Image
{
    public class Image : BaseEntity
    {
        public Image() { }


        public string Url { get; set; }
        public string Caption { get; set; }

        public long CompanyId { get; set; }
        public virtual Company.Company Company { get; set; }

        public virtual ICollection<PostImage.PostImage> PostImages { get; set; }
    }
}
