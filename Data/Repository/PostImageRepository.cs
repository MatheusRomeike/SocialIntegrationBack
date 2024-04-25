using Domain.Entities.PostImage;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Context;

namespace Data.Repository
{
    public class PostImageRepository : BaseRepository<PostImage, DataContext>, IPostImageRepository
    {
        private readonly DataContext Context;

        public PostImageRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
