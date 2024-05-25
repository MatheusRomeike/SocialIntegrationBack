using Application.ViewModels;
using Domain.Entities.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface ISocialMediaService
    {
        Task<IEnumerable<SocialMedia>> SocialMedias();
        Task<bool> PublishAsync(PublishViewModel model, long userId);
    }
}
