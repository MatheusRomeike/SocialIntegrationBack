using Application.Interfaces.ServiceInterfaces;
using Data.Interfaces.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SocialNetworkService : ISocialNetworkService
    {
        private readonly ISocialNetworkRepository _socialNetworkRepository;

        public SocialNetworkService(ISocialNetworkRepository socialNetworkRepository)
        {
            _socialNetworkRepository = socialNetworkRepository;
        }

        public async Task<IEnumerable<Domain.Entities.SocialNetwork.SocialNetwork>> GetAllAsync()
        {
            return await _socialNetworkRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Domain.Entities.SocialNetwork.SocialNetwork>> GetAllConfiguredAsync(long userId)
        {
            return await _socialNetworkRepository.GetAllAsync(
                predicate: p => p.Accounts.Where(x => x.UserId == userId).Any(),
                include: i => i.Include(x => x.Accounts));
        }
    }
}
