using FluentValidation;
using RateMovie.Communication.Requests.User;
using RateMovie.Exception;

namespace RateMovie.Application.UseCases.Users.Update
{
    public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.name).NotEmpty().WithMessage(ErrorMessagesResource.NAME_EMPTY);

            RuleFor(u => u.password).SetValidator(new PasswordValidator<RequestUpdateUserJson>());
        }
    }
}
