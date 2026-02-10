using RateMovie.Communication.Requests.User;

namespace RateMovie.Application.UseCases.Users.UpdatePassword
{
    public interface IUpdateUserPasswordUseCase
    {
        Task Execute(RequestUpdateUserPasswordJson request);
    }
}
