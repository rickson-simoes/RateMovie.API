using RateMovie.CommonUtilities.Entities;
using RateMovie.Communication.Requests.Login;
using RateMovie.Infrastructure.Security.PasswordHasher;
using RateMovie.IntegrationTests.CustomFactory;
using Shouldly;
using System.Net;
using System.Text.Json;

namespace RateMovie.IntegrationTests.Login
{
    public class LoginUseCaseTest : SqliteIntegrationTestBase
    {
        private const string LOGIN_URI = "api/login";

        public LoginUseCaseTest(CustomWebApplicationFactorySQLite webApplicationFactory) : base(webApplicationFactory) { }

        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var request = new RequestLoginJson(user.Email, user.Password);
            var hashedPassword = new PasswordHasherBcrypt().HashPassword(user.Password);
            user.Password = hashedPassword;

            await UseRateMovieDBContext(async db =>
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            });


            var response = await PostAsync(requestUri: LOGIN_URI, payload: request);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(responseContent);

            jsonDocument.RootElement.GetProperty("Email").GetString().ShouldBe(user.Email);
            jsonDocument.RootElement.GetProperty("Name").GetString().ShouldBe(user.Name);
            jsonDocument.RootElement.GetProperty("Token").GetString().ShouldNotBeNullOrEmpty();
        }

        // @TODO: EMAIL INVALID - bad request - ErrorMessagesResource.EMAIL_OR_PASSWORD_INVALID

        // @TODO: PASSWORD INVALID -  bad request - ErrorMessagesResource.EMAIL_OR_PASSWORD_INVALID
    }
}
