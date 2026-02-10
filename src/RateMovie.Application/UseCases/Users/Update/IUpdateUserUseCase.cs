using RateMovie.Communication.Requests.User;

namespace RateMovie.Application.UseCases.Users.Update
{
    public interface IUpdateUserUseCase
    {
        Task Execute(RequestUpdateUserJson request);
    }
}
