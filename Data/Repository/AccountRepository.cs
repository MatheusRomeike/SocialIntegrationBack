using Domain.Entities.Account;
using Data.Interfaces.RepositoryInterface;

namespace Data.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
    }
}
