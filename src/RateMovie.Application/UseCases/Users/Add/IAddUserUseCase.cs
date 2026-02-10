using RateMovie.Communication.Requests.User;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Users.Add
{
    public interface IAddUserUseCase
    {
        Task<ResponseAddUserJson> Execute(RequestAddUserJson req);
    }
}
