using FluentValidation.Results;
using RateMovie.Application.Mapper;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.PasswordHasher;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Users.Add
{
    internal class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IPasswordHasherBCrypt _passwordHasher;

        public AddUserUseCase(
            IUnitOfWorkRepository unitOfWork, 
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IPasswordHasherBCrypt passwordHasher)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAddUserJson> Execute(RequestAddUserJson req)
        {
            await RequestValidator(req);

            var user = req.RequestAddUserJsonToUser();
            user.Password = _passwordHasher.HashPassword(user.Password);

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

            var response = user.ResponseAddUserJsonToUser("token");

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
