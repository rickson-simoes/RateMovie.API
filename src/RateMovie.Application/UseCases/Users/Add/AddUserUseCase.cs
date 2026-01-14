using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Users.Add
{
    public class AddUserUseCase : IAddUserUseCase
    {
        public async Task<ResponseAddUserJson> Execute(RequestAddUserJson req)
        {
            
            return new ResponseAddUserJson(); 
        }


    }
}
