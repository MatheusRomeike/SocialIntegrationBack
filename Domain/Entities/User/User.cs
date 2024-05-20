using Domain.Entities.Core;

namespace Domain.Entities.User
{
    public class User : BaseEntity
    {
        public User() { }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Account.Account> Accounts { get; set; }
    }
}
