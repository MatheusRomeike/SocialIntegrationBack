using Domain.Entities.User;
using Data.Interfaces.RepositoryInterface;
using Application.Context;
using Domain.Entities.Account;


namespace Data.Repository
{
    public class AccountConfigurationRepository : BaseRepository<AccountConfiguration, DataContext>, IAccountConfigurationRepository
    {
        private readonly DataContext Context;

        public AccountConfigurationRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
