using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SocialNetworkController : BaseController
    {
        private readonly ISocialNetworkService _socialNetworkService;

        public SocialNetworkController(ISocialNetworkService socialNetworkService)
        {
            _socialNetworkService = socialNetworkService;
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return TaskAsync(async () => await _socialNetworkService.GetAllAsync());
        }

        [HttpGet("GetAllConfiguredAsync")]
        public Task<IActionResult> GetAllConfiguredAsync()
        {
            return TaskAsync(async () => await _socialNetworkService.GetAllConfiguredAsync(UserId));
        }
    }
}
