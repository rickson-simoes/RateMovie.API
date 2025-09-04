using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Movies.Get;
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
        [ProducesResponseType<ResponseListShortMovieJson>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetMovies([FromServices] IGetMoviesUseCase getMoviesUseCase)
        {
            var response = await getMoviesUseCase.Execute();

            if (response.Movies.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<ResponseMovieJson>(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterMovieUseCase movieUseCase, 
            [FromBody] RequestMovieJson req)
        {
            var response = await movieUseCase.Execute(req);

            return Created("", response);
        }
    }
}
