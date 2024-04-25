using Domain.Entities.Image;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Context;

namespace Data.Repository
{
    public class ImageRepository : BaseRepository<Image, DataContext>, IImageRepository
    {
        private readonly DataContext Context;

        public ImageRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
