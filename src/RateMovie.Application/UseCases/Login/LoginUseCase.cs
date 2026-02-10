using RateMovie.Communication.Requests.Login;
using RateMovie.Communication.Responses.Login;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Domain.Security.PasswordHasher;
using RateMovie.Domain.Security.TokenGenerator;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Login
{
    public class LoginUseCase(
        IUserReadOnlyRepository _userReadOnlyRepository, 
        IPasswordHasher _passwordHasher, 
        ITokenGenerator _TokenGenerator) : ILoginUseCase
    {
        public async Task<ResponseLoginJson> Execute(RequestLoginJson req)
        {
            var user = await _userReadOnlyRepository.GetByEmail(req.Email);

            if (user is null)
            {
                throw new GenericBadRequestError(ErrorMessagesResource.EMAIL_OR_PASSWORD_INVALID);
            }

            var verifyPassword = _passwordHasher.VerifyPassword(req.Password, user.Password);

            if (verifyPassword is false)
            {
                throw new GenericBadRequestError(ErrorMessagesResource.EMAIL_OR_PASSWORD_INVALID);
            }

            var token = _TokenGenerator.GenerateToken(user);

            var response = new ResponseLoginJson(user.Name, user.Email, token);

            return response;
        }
    }
}
