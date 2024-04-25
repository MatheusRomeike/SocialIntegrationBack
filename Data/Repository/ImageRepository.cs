using Domain.Entities.Image;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
    }
}
