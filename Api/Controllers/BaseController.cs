using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Utils.I18n.Interfaces;

namespace Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly II18nService _i18nService;

        public BaseController(II18nService i18nService)
        {
            _i18nService = i18nService;
        }

        public long UserId => Convert.ToInt64(HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "UserId")?.Value);
        public long CompanyId => Convert.ToInt64(HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "CompanyId")?.Value);
        public string Language => HttpContext.Request.Headers["X-Language"];


        protected async Task<IActionResult> TaskAsync(Func<Task<dynamic>> action)
        {
            try
            {
                return OkStandard(await action());
            }
            catch (Exception e)
            {
                _i18nService.Load(Language ?? "");
                var errorMessage = _i18nService.GetErrorMessage(e.GetType());
                return ResolveError(errorMessage);
            }
        }

        private IActionResult ResolveError(string errorMessage)
        {
            return BadRequest(new StandardReturn<string>(errorMessage, ReturnStatus.Error));
        }

        private IActionResult OkStandard<T>(T data)
        {
            var standardReturn = new StandardReturn<T>(data, ReturnStatus.Ok);
            return Ok(standardReturn);
        }
    }
}
