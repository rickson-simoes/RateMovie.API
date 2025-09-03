using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Movies.Register;
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
        public async Task<IActionResult> Register(
            [FromServices] IMovieUseCaseRegister MovieUseCase, 
            [FromBody] RequestMovieJson req)
        {
            var response = await MovieUseCase.Execute(req);

            return Created("", response);
        }
    }
}
