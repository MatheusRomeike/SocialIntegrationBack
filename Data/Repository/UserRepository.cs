using Domain.Entities.User;
using Data.Interfaces.RepositoryInterface;
using Application.Context;


namespace Data.Repository
{
    public class UserRepository : BaseRepository<User, DataContext>, IUserRepository
    {
        private readonly DataContext Context;

        public UserRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
