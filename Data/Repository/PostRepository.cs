using Domain.Entities.User;
using Data.Interfaces.RepositoryInterface;
using Application.Context;
using Domain.Entities.Post;


namespace Data.Repository
{
    public class PostRepository : BaseRepository<Post, DataContext>, IPostRepository
    {
        private readonly DataContext Context;

        public PostRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
