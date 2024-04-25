using Api.Models;
using Application.Interfaces;
using Application.Interfaces.ServiceInterfaces;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("LoginAsync")]
        public Task<IActionResult> LoginAsync([FromBody] UserViewModel user)
        {
            return TaskAsync(async () => await _userService.LoginAsync(user));
        }

        [AllowAnonymous]
        [HttpPost("RegisterAsync")]
        public Task<IActionResult> RegisterAsync([FromBody] UserRegisterViewModel user)
        {
            return TaskAsync(async () => await _userService.RegisterAsync(user));
        }
    }
}
