using FluentValidation;
using RateMovie.Communication.Requests.User;
using RateMovie.Exception;

namespace RateMovie.Application.UseCases.Users.Add
{
    public class AddUserValidator : AbstractValidator<RequestAddUserJson>
    {
        public AddUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage(ErrorMessagesResource.NAME_EMPTY);

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage(ErrorMessagesResource.EMAIL_EMPTY)
                .EmailAddress()
                .When(e => string.IsNullOrWhiteSpace(e.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage(ErrorMessagesResource.EMAIL_INVALID);

            RuleFor(u => u.Password).SetValidator(new PasswordValidator<RequestAddUserJson>());
        }
    }
}
