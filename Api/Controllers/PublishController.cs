using Api.Models;
using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using Domain.Domain.ViewModels;
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
        #region Atributos
        private readonly IPublishService _publishService;
        #endregion

        #region Construtor
        public PublishController(IPublishService publishService)
        {
            _publishService = publishService;
        }
        #endregion

        #region HttpPost
        [HttpPost("Publish")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(StandardReturn<bool>), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        [ProducesResponseType(500)]
        public Task<IActionResult> Publish([FromBody] PublishViewModel model)
        {
            return Task.Run(async () =>
            {
                try
                {
                    return Ok(new StandardReturn<bool>(ReturnStatus.Ok, await _publishService.PublishAsync(model)));
                }
                catch (Exception e)
                {
                    return ResolveError(e);
                }
            });
        }
        #endregion
    }
}
