using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Login
{
    public interface ILoginUseCase
    {
        Task<ResponseLoginJson> Execute(RequestLoginJson req);
    }
}
