using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface ISocialNetworkService
    {
        Task<IEnumerable<Domain.Entities.SocialNetwork.SocialNetwork>> GetAllAsync();
        Task<IEnumerable<Domain.Entities.SocialNetwork.SocialNetwork>> GetAllConfiguredAsync(long userId);
    }
}
