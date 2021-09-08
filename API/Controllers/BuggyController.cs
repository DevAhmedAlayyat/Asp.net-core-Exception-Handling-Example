using System;
using System.Net;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        [HttpGet("servererror")]
        public IActionResult ServerError()
        {
            throw new NullReferenceException("Server Error ......");
        }
        
        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        
        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            int? thing = null;

            if(thing == null)
                return NotFound(new ApiResponse(404));

            return Ok();
        }
        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetValidationError(int id)
        {
            return Ok();
        }
    }
}