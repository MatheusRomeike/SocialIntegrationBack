using Api.Models;
using Application.Interfaces;
using Application.Interfaces.ServiceInterfaces;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils.I18n.Interfaces;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, II18nService i18nService)
            : base(i18nService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public Task<IActionResult> Logar([FromBody] UserViewModel user)
        {
            return TaskAsync(async () => await _userService.LoginAsync(user));
        }
    }
}
