using Domain.Entities.User;
using Data.Interfaces.RepositoryInterface;
using Application.Context;
using Domain.Entities.SocialMedia;


namespace Data.Repository
{
    public class SocialMediaRepository : BaseRepository<SocialMedia, DataContext>, ISocialMediaRepository
    {
        private readonly DataContext Context;

        public SocialMediaRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
