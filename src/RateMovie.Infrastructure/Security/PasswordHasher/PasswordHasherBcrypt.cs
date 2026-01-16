using RateMovie.Domain.Security.PasswordHasher;

namespace RateMovie.Infrastructure.Security.PasswordHasher
{
    internal class PasswordHasherBcrypt : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);

            return hash;
        }

        public bool VerifyPassword(string password, string hash)
        {
            var verifyPwd = BCrypt.Net.BCrypt.Verify(password, hash);

            return verifyPwd;
        }
    }
}
