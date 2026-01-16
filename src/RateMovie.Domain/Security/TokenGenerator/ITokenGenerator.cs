using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Security.TokenGenerator
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
