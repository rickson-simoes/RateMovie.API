namespace RateMovie.Domain.PasswordHasher
{
    public interface IPasswordHasherBCrypt
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}
