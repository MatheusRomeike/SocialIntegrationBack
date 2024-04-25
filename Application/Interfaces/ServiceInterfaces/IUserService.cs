using Application.ViewModels;
using Domain.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
        Task<TokenDto> LoginAsync(UserViewModel user);
        Task<bool> RegisterAsync(UserRegisterViewModel user);
    }
}
