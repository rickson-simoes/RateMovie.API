using FluentValidation;
using RateMovie.Communication.Requests.User;

namespace RateMovie.Application.UseCases.Users.UpdatePassword
{
    public class UpdateUserPasswordValidator : AbstractValidator<RequestUpdateUserPasswordJson>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(u => u.password).SetValidator(new PasswordValidator<RequestUpdateUserPasswordJson>());
        }
    }
}
