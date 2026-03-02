using RateMovie.CommonUtilities.InlineClassData;
using RateMovie.CommonUtilities.Requests;
using RateMovie.Exception;
using RateMovie.IntegrationTests.CustomFactory;
using Shouldly;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace RateMovie.IntegrationTests.Movies.Add
{
    public class AddMovieUseCaseTest(CustomWebApplicationFactorySQLite webApplicationFactory) : SqliteIntegrationBaseClass(webApplicationFactory)
    {
        private const string MOVIE_URI = "api/Movies";

        [Fact]
        public async Task Success()
        {
            var user = await UseUserGeneratorInDBContext();

            var payload = RequestMovieJsonBuilder.Build();
            var request = await PostAsync(requestUri: MOVIE_URI, payload: payload, token: user.Token);

            request.StatusCode.ShouldBe(HttpStatusCode.Created);

            var readStream = await request.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(readStream);

            jsonDocument.RootElement.GetProperty("Name").GetString().ShouldBe(payload.Name);
            jsonDocument.RootElement.GetProperty("Comment").GetString().ShouldBe(payload.Comment);
            jsonDocument.RootElement.GetProperty("Stars").GetByte().ShouldBe(payload.Stars);
            jsonDocument.RootElement.GetProperty("Genre").GetInt32().ShouldBe((int)payload.Genre);
            jsonDocument.RootElement.GetProperty("CreatedAt").GetString().ShouldNotBeNullOrWhiteSpace();
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_If_Name_Is_Null(string culture)
        {
            var user = await UseUserGeneratorInDBContext();

            var payload = RequestMovieJsonBuilder.Build();
            payload.Name = string.Empty;

            var request = await PostAsync(requestUri: MOVIE_URI, payload: payload, token: user.Token, culture: culture);

            request.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var readStream = await request.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(readStream);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();
            var resourceMsg = ErrorMessagesResource.ResourceManager.GetString("MOVIE_NAME_CANT_BE_NULL", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(err => err.ToString() == resourceMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.Contains(expectedMsg);
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_When_Name_Length_Exceeds_Max(string culture)
        {
            var user = await UseUserGeneratorInDBContext();

            var payload = RequestMovieJsonBuilder.Build();
            payload.Name = string.Create(91, 'A', (span, state) => span.Fill(state));

            var request = await PostAsync(requestUri: MOVIE_URI, payload: payload, token: user.Token, culture: culture);

            request.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var readStream = await request.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(readStream);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();
            var resourceMsg = ErrorMessagesResource.ResourceManager.GetString("MOVIE_NAME_MAX_CHARACTER_LENGTH", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(err => err.ToString() == resourceMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.Contains(expectedMsg);
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_When_Comment_Length_Exceeds_Max(string culture)
        {
            var user = await UseUserGeneratorInDBContext();

            var payload = RequestMovieJsonBuilder.Build();
            payload.Comment = string.Create(701, 'A', (span, state) => span.Fill(state));

            var request = await PostAsync(requestUri: MOVIE_URI, payload: payload, token: user.Token, culture: culture);

            request.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var readStream = await request.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(readStream);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();
            var resourceMsg = ErrorMessagesResource.ResourceManager.GetString("MOVIE_COMMENT_MAX_CHARACTER_LENGTH", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(err => err.ToString() == resourceMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.Contains(expectedMsg);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public async Task Should_Fail_When_Stars_Out_Of_Range(byte stars)
        {
            var user = await UseUserGeneratorInDBContext();

            var payload = RequestMovieJsonBuilder.Build();
            payload.Stars = stars;

            var request = await PostAsync(requestUri: MOVIE_URI, payload: payload, token: user.Token);

            request.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var readStream = await request.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(readStream);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();
            var resourceMsg = ErrorMessagesResource.ResourceManager.GetString("MOVIE_STARS_BETWEEN_RANGE");
            var expectedMsg = errMsgs.First(err => err.ToString() == resourceMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.Contains(expectedMsg);
        }

        [Theory]
        [ClassData(typeof(InlineCultureClassData))]
        public async Task Should_Fail_When_Genre_Is_Invalid(string culture)
        {
            var user = await UseUserGeneratorInDBContext();

            var payload = RequestMovieJsonBuilder.Build();
            payload.Genre = (Communication.Enum.MovieGenre)6;

            var request = await PostAsync(requestUri: MOVIE_URI, payload: payload, token: user.Token, culture: culture);

            request.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

            var readStream = await request.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(readStream);

            var errMsgs = jsonDocument.RootElement.GetProperty("ErrorResponse").EnumerateArray();
            var resourceMsg = ErrorMessagesResource.ResourceManager.GetString("MOVIE_GENRE_INVALID", new CultureInfo(culture));
            var expectedMsg = errMsgs.First(err => err.ToString() == resourceMsg);

            errMsgs.Count().ShouldBe(1);
            errMsgs.Contains(expectedMsg);
        }
    }
}
