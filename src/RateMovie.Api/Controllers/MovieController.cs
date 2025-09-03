using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Movie.Register;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;

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
        [ProducesResponseType<ResponseMovieJson>(StatusCodes.Status201Created)]
        public IActionResult Register(
            [FromServices] IMovieUseCaseRegister MovieUseCase, 
            [FromBody] RequestMovieJson req)
        {
            var response = MovieUseCase.Execute(req);

            return Created("", response);
        }
    }
}
