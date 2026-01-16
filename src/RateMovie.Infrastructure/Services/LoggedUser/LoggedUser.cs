using Microsoft.EntityFrameworkCore;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Security.AccessTokenProvider;
using RateMovie.Domain.Services;
using RateMovie.Infrastructure.DataAccess;
using RateMovie.Infrastructure.Security.TokenGenerator;
using System.IdentityModel.Tokens.Jwt;

namespace RateMovie.Infrastructure.Services.LoggedUser
{
    internal class LoggedUser(RateMovieDBContext _dbContext, IAccessTokenProvider _tokenProvider) : ILoggedUser
    {
        public async Task<User> Get()
        {
            var TokenJWT = _tokenProvider.GetToken();

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.ReadJwtToken(TokenJWT);

            var userEmail = token.Claims.First(claim => claim.Type == TokenGeneratorTypes.EMAIL).Value;

            var user = await _dbContext.Users.AsNoTracking().FirstAsync(user => user.Email == userEmail);

            return user;
        }
    }
}
