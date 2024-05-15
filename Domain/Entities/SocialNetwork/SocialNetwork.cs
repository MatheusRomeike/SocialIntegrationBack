
using Domain.Entities.Core;
using Domain.Entities.SocialNetwork.Enums;

namespace Domain.Entities.SocialNetwork
{
    public class SocialNetwork : BaseEntity
    {
        public SocialNetwork() { }


        public string Name { get; set; }
        public string Url { get; set; }
        public string BaseUrlApi { get; set; }

        public virtual ICollection<Account.Account> Accounts { get; set; }

    }
}
