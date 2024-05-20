using Domain.Entities.User;
using Data.Interfaces.RepositoryInterface;
using Application.Context;
using Domain.Entities.SocialMedia;


namespace Data.Repository
{
    public class SocialMediaConfigurationRepository : BaseRepository<SocialMediaConfiguration, DataContext>, ISocialMediaConfigurationRepository
    {
        private readonly DataContext Context;

        public SocialMediaConfigurationRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
