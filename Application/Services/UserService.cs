using Application.Interfaces.ServiceInterfaces;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public async Task<string> LoginAsync(UserViewModel user)
        {
            throw new NotImplementedException();
            return await Task.Run(() => "Login realizado com sucesso");
        }
    }
}
