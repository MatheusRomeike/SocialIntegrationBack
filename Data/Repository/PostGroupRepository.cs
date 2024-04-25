using Domain.Entities.PostGroup;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Context;

namespace Data.Repository
{
    public class PostGroupRepository : BaseRepository<PostGroup, DataContext>, IPostGroupRepository
    {
        private readonly DataContext Context;

        public PostGroupRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
