using RateMovie.Application.Mapper;
using RateMovie.Communication.Responses.User;
using RateMovie.Domain.Services;

namespace RateMovie.Application.UseCases.Users.GetAllData
{
    internal class GetAllUserDataUseCase(ILoggedUser _loggedUser) : IGetAllUserDataUseCase
    {
        public async Task<ResponseGetAllUserDataJson> Execute()
        {
            var user = await _loggedUser.Get();
            var response = user.ToGetAllUserDataJson();

            return response;
        }
    }
}
