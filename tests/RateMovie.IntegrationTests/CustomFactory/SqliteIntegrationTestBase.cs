using Microsoft.Extensions.DependencyInjection;
using RateMovie.Infrastructure.DataAccess;

namespace RateMovie.IntegrationTests.CustomFactory
{
    public abstract class SqliteIntegrationTestBase : IClassFixture<CustomWebApplicationFactorySQLite>
    {
        protected readonly HttpClient _httpClient;

        public SqliteIntegrationTestBase(CustomWebApplicationFactorySQLite webApplicationFactory)
        {
            _httpClient = webApplicationFactory.CreateClient();

            using var scope = webApplicationFactory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RateMovieDBContext>();
            db.Database.EnsureCreated();
        }
    }
}
