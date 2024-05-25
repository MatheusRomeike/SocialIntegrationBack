using Domain.Entities.SocialMedia.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PublishViewModel
    {
        public string Text { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<SocialMediaType> SocialMediaTypes { get; set; }

    }
}
