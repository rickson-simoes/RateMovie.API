using RateMovie.Communication.Responses.User;

namespace RateMovie.Application.UseCases.Users.PatchVip
{
    public interface IPatchVipUserUseCase
    {
        Task<ResponsePatchVipUserJson> Execute();
    }
}
