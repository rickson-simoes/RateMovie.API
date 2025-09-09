using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Movies.Add;
using RateMovie.Application.UseCases.Movies.GetAll;
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
        public async Task<IActionResult> GetAll([FromServices] IGetAllMoviesUseCase getAllMoviesUseCase)
        {
            var response = await getAllMoviesUseCase.Execute();

            if (response.Movies.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<ResponseMovieJson>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(
            [FromServices] IAddMovieUseCase addMovieUseCase,
            [FromBody] RequestMovieJson req)
        {
            var response = await addMovieUseCase.Execute(req);

            return Created("", response);
        }
    }
}
