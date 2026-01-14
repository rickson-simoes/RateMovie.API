using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Users.Add;
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
            [FromServices] IAddUserUseCase userUseCase) 
        {
           var useCase = await userUseCase.Execute(req);

            return Created(string.Empty, useCase);
        }
    }
}
