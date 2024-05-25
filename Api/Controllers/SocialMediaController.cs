using Application.Interfaces.ServiceInterfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SocialMediaController : BaseController
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMedias()
        {
            return await TaskAsync(async () => await _socialMediaService.SocialMedias());
        }

        [HttpPost("PublishAsync")]
        public async Task<IActionResult> PublishAsync([FromBody] PublishViewModel model)
        {
            return await TaskAsync(async () => await _socialMediaService.PublishAsync(model, UserId));
        }
    }
}
