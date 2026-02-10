using RateMovie.Communication.Requests.Login;
using RateMovie.Communication.Responses.Login;

namespace RateMovie.Application.UseCases.Login
{
    public interface ILoginUseCase
    {
        Task<ResponseLoginJson> Execute(RequestLoginJson req);
    }
}
