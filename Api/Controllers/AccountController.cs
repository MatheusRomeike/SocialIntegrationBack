using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Accounts()
        {
            return await TaskAsync(async () => await _accountService.Accounts(UserId));
        }

        [HttpGet("AuthenticateAsync")]
        public async Task<IActionResult> AuthenticateAsync(string code, string socialMediaName)
        {
            return await TaskAsync(async () => await _accountService.AuthenticateAsync(code, socialMediaName, UserId));
        }

        [HttpDelete("{socialMediaName}")]
        public async Task<IActionResult> DisconnectAccountAsync(string socialMediaName)
        {
            return await TaskAsync(async () => await _accountService.DisconnectAccountAsync(socialMediaName, UserId));
        }
    }
}
