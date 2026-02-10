using Microsoft.AspNetCore.Mvc;
using RateMovie.Application.UseCases.Login;
using RateMovie.Communication.Requests.Login;
using RateMovie.Communication.Responses;
using RateMovie.Communication.Responses.Login;

namespace RateMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<ResponseLoginJson>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(
            [FromServices] ILoginUseCase loginUseCase, 
            [FromBody] RequestLoginJson req)
        {
            var response = await loginUseCase.Execute(req);

             return Ok(response);
        }
    }
}
