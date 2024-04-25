using Domain.Entities.SocialNetwork.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PublishViewModel
    {
        public string PostGroupTitle { get; set; }
        public string PostGroupDescription { get; set; }
        public string Content { get; set; }
        public List<SocialNetworkType> SocialNetworkTypes { get; set; }
    }
}
