using Domain.Entities.SocialNetwork;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Context;

namespace Data.Repository
{
    public class SocialNetworkRepository : BaseRepository<SocialNetwork, DataContext>, ISocialNetworkRepository
    {
        private readonly DataContext Context;

        public SocialNetworkRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
