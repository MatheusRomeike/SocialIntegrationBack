using Domain.Entities.PostImage;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PostImageRepository : BaseRepository<PostImage>, IPostImageRepository
    {
    }
}
