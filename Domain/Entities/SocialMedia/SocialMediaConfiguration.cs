using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SocialMedia
{
    public class SocialMediaConfiguration : BaseEntity
    {
        public string BaseUrl { get; set; }
        public string AuthorizationUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string ResponseType { get; set; }
        public string Scope { get; set; }
        public string GrantType { get; set; }
        public string ExtraUrlInfo { get; set; }

        public virtual SocialMedia SocialMedia { get; set; }
    }
}
