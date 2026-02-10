using RateMovie.Communication.Requests.User;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Domain.Security.PasswordHasher;
using RateMovie.Domain.Services;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Users.UpdatePassword
{
    public class UpdateUserPasswordUseCase(
        IUnitOfWorkRepository _unitOfWork, 
        ILoggedUser _loggedUser, 
        IPasswordHasher _passwordHasher, 
        IUserWriteOnlyRepository _userWriteRepository) : IUpdateUserPasswordUseCase
    {
        public async Task Execute(RequestUpdateUserPasswordJson request)
        {
            Validator(request);

            var user = await _loggedUser.Get();
            user.Password = _passwordHasher.HashPassword(request.password);

            _userWriteRepository.Update(user);
            await _unitOfWork.Commit();
        }

        private void Validator(RequestUpdateUserPasswordJson request)
        {
            var validation = new UpdateUserPasswordValidator().Validate(request);

            if (validation.IsValid is false)
            {
                var errMsg = validation.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ValidationHandlerException(errMsg);
            }
        }
    }
}
