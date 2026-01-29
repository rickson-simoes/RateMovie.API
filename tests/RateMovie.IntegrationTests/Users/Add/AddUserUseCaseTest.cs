using RateMovie.CommonUtilities.Requests;
using RateMovie.IntegrationTests.CustomFactory;
using Shouldly;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace RateMovie.IntegrationTests.Users.Add
{
    public class AddUserUseCaseTest : SqliteIntegrationTestBase
    {        
        private const string USER_URI = "api/users";

        public AddUserUseCaseTest(CustomWebApplicationFactorySQLite webApplicationFactory) : base(webApplicationFactory)
        {
        }

        [Fact]
        public async Task Success()
        {
            var request = RequestAddUserJsonBuilder.Build();

            //_httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("pt-BR"));
            //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "JWT");

            var response = await _httpClient.PostAsJsonAsync(USER_URI, request);

            response.StatusCode.ShouldBe(HttpStatusCode.Created);

            var responseContent = await response.Content.ReadAsStreamAsync();
            var jsonDocument = await JsonDocument.ParseAsync(responseContent);

           jsonDocument.RootElement.GetProperty("Name").GetString().ShouldBe(request.Name);
        }
    }
}
