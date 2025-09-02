using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace RateMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        [HttpGet]
        public IActionResult Register()
        {
            return Ok(new { Message = "Hello"});
        }

        [HttpPost]
        public IActionResult Post() 
        {

            return Created("", new {Message = "Done"});
        }
    }
}
