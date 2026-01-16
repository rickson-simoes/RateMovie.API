using Microsoft.IdentityModel.Tokens;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Security.TokenGenerator;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RateMovie.Infrastructure.Security.TokenGenerator
{
    public class TokenGeneratorJWT : ITokenGenerator
    {
        private readonly int _expirationTime;
        private readonly string _signingKey;

        public TokenGeneratorJWT(string signingKey, int expirationTime)
        {
            _signingKey = signingKey;
            _expirationTime = expirationTime;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));

            Dictionary<string, object> claims =  new ()
            {
                { TokenGeneratorTypes.ROLE, user.Role.ToString() },
                { TokenGeneratorTypes.EMAIL, user.Email }
            };

            var descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTime),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Claims = claims
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            var TokenJWT = tokenHandler.WriteToken(securityToken);

            return TokenJWT;
        }
    }
}
