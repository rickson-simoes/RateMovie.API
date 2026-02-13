using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Domain.Services;

namespace RateMovie.Application.UseCases.Users.Delete
{
    internal class DeleteUserUseCase(
        IUnitOfWorkRepository _unitOfWork, 
        IUserDeleteOnlyRepository _userRepositoryDelete, 
        ILoggedUser _loggedUser) : IDeleteUserUseCase
    {
        public async Task Execute()
        {
            var user = await _loggedUser.Get();

            _userRepositoryDelete.Delete(user);

            await _unitOfWork.Commit();
        }
    }
}
