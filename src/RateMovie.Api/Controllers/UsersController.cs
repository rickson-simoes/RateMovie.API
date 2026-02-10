using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Users.Add;
using RateMovie.Application.UseCases.Users.Delete;
using RateMovie.Application.UseCases.Users.Update;
using RateMovie.Communication.Requests.User;
using RateMovie.Communication.Responses;
using RateMovie.Communication.Responses.User;

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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(
            [FromServices] IUpdateUserUseCase updateUseCase, 
            [FromBody] RequestUpdateUserJson request)
        {
           await updateUseCase.Execute(request);

           return NoContent();
        }
    }
}
