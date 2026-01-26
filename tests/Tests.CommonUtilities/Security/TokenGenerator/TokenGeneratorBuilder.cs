using Moq;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Security.TokenGenerator;

namespace RateMovie.CommonUtilities.Security.TokenGenerator
{
    public class TokenGeneratorBuilder
    {
        public static ITokenGenerator Build()
        {
            var tokenGenerator = new Mock<ITokenGenerator>();

            tokenGenerator.Setup(tokenGenerator => tokenGenerator.GenerateToken(It.IsAny<User>())).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiTWVtYmVyIiwiZW1haWwiOiJyaWNrc29uLnNpbW9lc0Bob3RtYWlsLmNvbSIsIm5iZiI6MTc2ODU4ODkxNCwiZXhwIjoxNzY5MTg4OTE0LCJpYXQiOjE3Njg1ODg5MTR9.QIZTo_YDMFG06l1gOKa7EAz0thRZfweZ91aVtyXpH2k");

            return tokenGenerator.Object;
        }
    }
}
