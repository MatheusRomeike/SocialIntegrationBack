using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public long UserId => Convert.ToInt64(HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "UserId")?.Value);

        protected async Task<IActionResult> TaskAsync(Func<Task<dynamic>> action)
        {
            try
            {
                return OkStandard(await action());
            }
            catch (Exception e)
            {
                return ResolveError(e.Message);
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
