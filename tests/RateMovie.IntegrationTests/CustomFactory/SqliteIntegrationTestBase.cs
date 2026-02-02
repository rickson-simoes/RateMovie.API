using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using RateMovie.Infrastructure.DataAccess;
using System.Net.Http.Json;

namespace RateMovie.IntegrationTests.CustomFactory
{
    public abstract class SqliteIntegrationTestBase : IClassFixture<CustomWebApplicationFactorySQLite>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactorySQLite _webApplicationFactory;

        public SqliteIntegrationTestBase(CustomWebApplicationFactorySQLite webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
            _httpClient = webApplicationFactory.CreateClient();

            using var scope = webApplicationFactory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RateMovieDBContext>();
            db.Database.EnsureCreated();
        }

        private protected async Task UseRateMovieDBContext(Func<RateMovieDBContext, Task> action)
        {
            using var scope = _webApplicationFactory.Services.CreateScope();
            RateMovieDBContext db = scope.ServiceProvider.GetRequiredService<RateMovieDBContext>();
            await action(db);
        }

        private void AddAuthorizationJWT(string? token = null)
        {
            if (string.IsNullOrWhiteSpace(token) is false)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
            }
        }

        private void AddAcceptLanguageCultureHeader(string? culture = null)
        {
            if (string.IsNullOrWhiteSpace(culture) is false)
            {
                _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(culture));
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, object payload, string? token = null, string? culture = null)
        {
            AddAuthorizationJWT(token);
            AddAcceptLanguageCultureHeader(culture);

            var response = await _httpClient.PostAsJsonAsync(requestUri, payload);

            return response;
        }
    }
}
