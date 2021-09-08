using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("errors/{code}")]
    public class NotFoundErrorController : ControllerBase
    {
        public IActionResult HandleNotFoundEndPoints(int code)
        {
            return new ObjectResult(new ApiResponse(404));
        }
    }
}