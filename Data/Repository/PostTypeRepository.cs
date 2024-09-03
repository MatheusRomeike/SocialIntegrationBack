using Application.Context;
using Data.Interfaces.RepositoryInterface;
using Domain.Entities.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PostTypeRepository : BaseRepository<PostType, DataContext>, IPostTypeRepository
    {
        private readonly DataContext Context;

        public PostTypeRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
