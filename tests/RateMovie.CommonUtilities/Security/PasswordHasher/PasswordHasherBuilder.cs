using Moq;
using RateMovie.Domain.Security.PasswordHasher;

namespace RateMovie.CommonUtilities.Security.PasswordHasher
{
    public class PasswordHasherBuilder
    {
        private readonly Mock<IPasswordHasher> _passwordHasher;

        public PasswordHasherBuilder()
        {
            _passwordHasher = new Mock<IPasswordHasher>();
        }

        public PasswordHasherBuilder HashPassword()
        {
            _passwordHasher.Setup(pwdHash => pwdHash.HashPassword(It.IsAny<string>())).Returns("P4ssw0rdH4sh3rM0Ck!");

            return this;
        }

        public PasswordHasherBuilder VerifyPassword(string? password)
        {
            if (password is not null)
            {
                _passwordHasher.Setup(pwdHash => pwdHash.VerifyPassword(password, It.IsAny<string>())).Returns(true);
            }

            return this;
        }

        public IPasswordHasher Build() => _passwordHasher.Object;
    }
}
