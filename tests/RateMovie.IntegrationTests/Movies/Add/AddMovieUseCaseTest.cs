using RateMovie.CommonUtilities.InlineClassData;
using RateMovie.CommonUtilities.Requests;
using RateMovie.IntegrationTests.CustomFactory;
using Shouldly;
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
    }
}
