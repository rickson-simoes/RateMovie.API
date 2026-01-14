using RateMovie.Domain.PasswordHasher;

namespace RateMovie.Infrastructure.PasswordHasher
{
    internal class PasswordHasherBcrypt : IPasswordHasherBCrypt
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
