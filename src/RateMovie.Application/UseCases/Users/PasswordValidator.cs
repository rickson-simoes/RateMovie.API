using FluentValidation;
using FluentValidation.Validators;
using RateMovie.Exception;
using System.Text.RegularExpressions;

namespace RateMovie.Application.UseCases.Users
{
    public partial class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PasswordValidator";

        private const string ERROR_MSG = "ErrorMessage";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MSG}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MSG, ErrorMessagesResource.PASSWORD_INVALID);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MSG, ErrorMessagesResource.PASSWORD_INVALID);
                return false;
            }

            if (DetectUppercaseLetter().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MSG, ErrorMessagesResource.PASSWORD_INVALID);
                return false;
            }

            if (DetectLowercaseLetter().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MSG, ErrorMessagesResource.PASSWORD_INVALID);
                return false;
            }

            if (DetectSpecialCharacter().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MSG, ErrorMessagesResource.PASSWORD_INVALID);
                return false;
            }

            if (DetectNumber().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MSG, ErrorMessagesResource.PASSWORD_INVALID);
                return false;
            }

            return true;
        }

        [GeneratedRegex("[A-Z]+")]
        private partial Regex DetectUppercaseLetter();

        [GeneratedRegex("[a-z]+")]
        private partial Regex DetectLowercaseLetter();

        [GeneratedRegex("[!@#$%¨&*()]")]
        private partial Regex DetectSpecialCharacter();

        [GeneratedRegex("[0-9]")]
        private partial Regex DetectNumber();
    }
}
