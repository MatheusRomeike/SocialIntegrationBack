using Api.Models;
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
    public class PublishController : BaseController
    {
        private readonly IPublishService _publishService;

        public PublishController(IPublishService publishService)
        {
            _publishService = publishService;
        }

        [HttpPost("Publish")]
        public Task<IActionResult> Publish([FromBody] PublishViewModel model)
        {
            return TaskAsync(async () => await _publishService.PublishAsync(model, UserId));
        }
    }
}
