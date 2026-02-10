using RateMovie.Communication.Requests.User;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Domain.Security.PasswordHasher;
using RateMovie.Domain.Services;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Users.Update
{
    internal class UpdateUserUseCase(
        IUnitOfWorkRepository _unitOfWork, 
        IUserWriteOnlyRepository _userRepositoryWrite, 
        ILoggedUser _loggedUser,
        IPasswordHasher _passwordHasher): IUpdateUserUseCase
    {
        public async Task Execute(RequestUpdateUserJson request)
        {
            RequestValidator(request);

            var user = await _loggedUser.Get();

            user.Name = request.name;
            user.Password = _passwordHasher.HashPassword(request.password);

            _userRepositoryWrite.Update(user);
            await _unitOfWork.Commit();
        }

        private void RequestValidator(RequestUpdateUserJson request)
        {
            var validator = new UpdateUserValidator().Validate(request);

            if (validator.IsValid is false)
            {
                var errMessages = validator.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ValidationHandlerException(errMessages);
            }
        }
    }
}
