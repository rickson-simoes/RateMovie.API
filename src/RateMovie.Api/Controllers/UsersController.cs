using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Users.Add;
using RateMovie.Application.UseCases.Users.Delete;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;

namespace RateMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<ResponseAddUserJson>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser(
            [FromBody] RequestAddUserJson req,
            [FromServices] IAddUserUseCase addUserUseCase) 
        {
           var useCase = await addUserUseCase.Execute(req);

            return Created(string.Empty, useCase);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromServices] IDeleteUserUseCase deleteUserUseCase)
        {
            await deleteUserUseCase.Execute();

            return NoContent();
        }
    }
}
