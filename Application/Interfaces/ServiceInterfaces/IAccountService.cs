using Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> Accounts(long userId);
        Task<bool> AuthenticateAsync(string code, string socialMediaName, long userId);
        Task<bool> DisconnectAccountAsync(string socialMediaName, long userId);
    }
}
