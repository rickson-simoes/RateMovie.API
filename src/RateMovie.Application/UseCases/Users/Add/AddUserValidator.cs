using FluentValidation;
using RateMovie.Communication.Requests;
using RateMovie.Exception;

namespace RateMovie.Application.UseCases.Users.Add
{
    public class AddUserValidator : AbstractValidator<RequestAddUserJson>
    {
        public AddUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage(ErrorMessagesResource.NAME_EMPTY);

            RuleFor(u => u.Email).EmailAddress().WithMessage(ErrorMessagesResource.EMAIL_INVALID);

            RuleFor(u => u.Password).SetValidator(new PasswordValidator<RequestAddUserJson>());
        }
    }
}
