using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Users.Add;
using RateMovie.Application.UseCases.Users.Delete;
using RateMovie.Application.UseCases.Users.PatchVip;
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
           var response = await addUserUseCase.Execute(req);

            return Created(string.Empty, response);
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

        [HttpPatch]
        [ProducesResponseType<ResponsePatchVipUserJson>(StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchVipUser([FromServices] IPatchVipUserUseCase patchVipUseCase)
        {
            var response = await patchVipUseCase.Execute();

            return Ok(response);
        }
    }
}
