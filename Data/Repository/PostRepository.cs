using Domain.Entities.Post;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Context;

namespace Data.Repository
{
    public class PostRepository : BaseRepository<Post, DataContext>, IPostRepository
    {
        private readonly DataContext Context;

        public PostRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
