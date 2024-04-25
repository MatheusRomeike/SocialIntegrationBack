using Domain.Entities.User;
using Data.Interfaces.RepositoryInterface;


namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}
