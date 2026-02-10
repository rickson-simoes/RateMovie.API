using RateMovie.Communication.Responses.User;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Domain.Security.TokenGenerator;
using RateMovie.Domain.Services;

namespace RateMovie.Application.UseCases.Users.PatchVip
{
    internal class PatchVipUserUseCase(
        IUnitOfWorkRepository _unitOfWork, 
        ILoggedUser _loggedUser,
        IUserWriteOnlyRepository _userRepositoryWrite,
        ITokenGenerator _tokenGenerator) : IPatchVipUserUseCase
    {
        public async Task<ResponsePatchVipUserJson> Execute()
        {
            var user = await _loggedUser.Get();
            user.Role = Domain.Enum.UserRole.Vip;

            _userRepositoryWrite.Update(user);
            await _unitOfWork.Commit();

            var token = _tokenGenerator.GenerateToken(user);

            return new ResponsePatchVipUserJson(token);
        }
    }
}
