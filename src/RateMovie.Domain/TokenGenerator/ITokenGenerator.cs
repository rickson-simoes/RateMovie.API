using RateMovie.Domain.Entities;

namespace RateMovie.Domain.TokenGenerator
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
