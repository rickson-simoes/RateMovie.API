using FluentValidation.Results;
using RateMovie.Application.Mapper;
using RateMovie.Communication.Requests.User;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Domain.Security.PasswordHasher;
using RateMovie.Domain.Security.TokenGenerator;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Users.Add
{
    internal class AddUserUseCase(
        IUnitOfWorkRepository _unitOfWork,
        IUserWriteOnlyRepository _userWriteOnlyRepository,
        IUserReadOnlyRepository _userReadOnlyRepository,
        IPasswordHasher _passwordHasher,
        ITokenGenerator _tokenGenerator) : IAddUserUseCase
    {
        public async Task<ResponseAddUserJson> Execute(RequestAddUserJson req)
        {
            await RequestValidator(req);

            var user = req.ToUser();
            user.Password = _passwordHasher.HashPassword(user.Password);

            var token = _tokenGenerator.GenerateToken(user);

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

            var response = user.ToResponseAddUserJson(token);

            return response;
        }

        private async Task RequestValidator(RequestAddUserJson req)
        {
            var userValidator = new AddUserValidator();
            var validationFailures = userValidator.Validate(req);

            var IsEmailRegistered = await _userReadOnlyRepository.EmailExists(req.Email);

            if (IsEmailRegistered)
            {
                validationFailures.Errors.Add(new ValidationFailure("", ErrorMessagesResource.EMAIL_ALREADY_EXISTS));
            }

            if (validationFailures.IsValid is false)
            {
                var errMsgs = validationFailures.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ValidationHandlerException(errMsgs);
            }
        }
    }
}
