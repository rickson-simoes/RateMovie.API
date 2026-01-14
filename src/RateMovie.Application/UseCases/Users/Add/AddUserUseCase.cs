using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Users.Add
{
    public class AddUserUseCase : IAddUserUseCase
    {
        public async Task<ResponseAddUserJson> Execute(RequestAddUserJson req)
        {
            RequestValidator(req);

            return new ResponseAddUserJson();
        }

        private void RequestValidator(RequestAddUserJson req)
        {
            var userValidator = new AddUserValidator();
            var validationFailures = userValidator.Validate(req);

            if (validationFailures.IsValid is false)
            {
                var errMsgs = validationFailures.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ValidationHandlerException(errMsgs);
            }
        }
    }
}
