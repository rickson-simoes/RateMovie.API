using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.InlineClassData;
using RateMovie.CommonUtilities.Requests;
using RateMovie.Exception;
using RateMovie.IntegrationTests.CustomFactory;
using Shouldly;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace RateMovie.IntegrationTests.Users.Add
{
    public class AddUserUseCaseTest(CustomWebApplicationFactorySQLite webApplicationFactory) : SqliteIntegrationTestBase(webApplicationFactory)
    {        
        private const string USER_URI = "api/users";

        [Fact]
        public async Task Success()
        {
            var request = RequestAddUserJsonBuilder.Build();

            var response = await PostAsync(requestUri: USER_URI, payload: request);

            response.StatusCode.ShouldBe(HttpStatusCode.Created);

            var responseContent = await response.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(responseContent);

           jsonDocument.RootElement.GetProperty("Name").GetString().ShouldBe(request.Name);
           jsonDocument.RootElement.GetProperty("Email").GetString().ShouldBe(request.Email);
           jsonDocument.RootElement.GetProperty("Token").GetString().ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_When_Name_Is_Empty(string culture)
        {
            var request = RequestAddUserJsonBuilder.Build();
            request.Name = string.Empty;

            var response = await PostAsync(USER_URI, request, culture: culture);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(responseContent);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();

            var resourceCultureMsg = ErrorMessagesResource.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(msg => msg.ToString() == resourceCultureMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.ShouldContain(expectedMsg);
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_When_Email_Is_Empty(string culture)
        {
            var request = RequestAddUserJsonBuilder.Build();
            request.Email = string.Empty;

            var response = await PostAsync(USER_URI, request, culture: culture);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(responseContent);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();

            var resourceCultureMsg = ErrorMessagesResource.ResourceManager.GetString("EMAIL_EMPTY", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(msg => msg.ToString() == resourceCultureMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.ShouldContain(expectedMsg);
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_When_Email_Is_Invalid(string culture)
        {
            var request = RequestAddUserJsonBuilder.Build();
            request.Email = "invalidEmail@";

            var response = await PostAsync(USER_URI, request, culture: culture);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(responseContent);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();

            var resourceCultureMsg = ErrorMessagesResource.ResourceManager.GetString("EMAIL_INVALID", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(msg => msg.ToString() == resourceCultureMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.ShouldContain(expectedMsg);
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_When_Email_Already_Exists(string culture)
        {
            var user = UserBuilder.Build();

            await UseRateMovieDBContext(async db =>
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            });

            var request = RequestAddUserJsonBuilder.Build();
            request.Email = user.Email;

            var response = await PostAsync(USER_URI, request, culture: culture);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var responseContent = await response.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(responseContent);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();

            var resourceCultureMsg = ErrorMessagesResource.ResourceManager.GetString("EMAIL_ALREADY_EXISTS", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(msg => msg.ToString() == resourceCultureMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.ShouldContain(expectedMsg);
        }
    }
}
