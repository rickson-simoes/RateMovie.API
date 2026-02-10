using RateMovie.Communication.Responses.User;

namespace RateMovie.Application.UseCases.Users.GetAllData
{
    public interface IGetAllUserDataUseCase
    {
        Task<ResponseGetAllUserDataJson> Execute();
    }
}
