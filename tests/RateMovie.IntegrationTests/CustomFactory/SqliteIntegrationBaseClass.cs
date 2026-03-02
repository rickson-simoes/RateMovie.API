using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.TestModels;
using RateMovie.Domain.Security.TokenGenerator;
using RateMovie.Infrastructure.DataAccess;
using RateMovie.Infrastructure.Security.PasswordHasher;
using System.Net.Http.Json;

namespace RateMovie.IntegrationTests.CustomFactory
{
    public abstract class SqliteIntegrationBaseClass : IClassFixture<CustomWebApplicationFactorySQLite>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactorySQLite _webApplicationFactory;
        private readonly ITokenGenerator _tokenGenerator;

        public SqliteIntegrationBaseClass(CustomWebApplicationFactorySQLite webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
            _httpClient = webApplicationFactory.CreateClient();

            using var scope = webApplicationFactory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RateMovieDBContext>();
            _tokenGenerator = scope.ServiceProvider.GetRequiredService<ITokenGenerator>();

            db.Database.EnsureCreated();
        }

        private protected async Task UseRateMovieDBContext(Func<RateMovieDBContext, Task> action)
        {
            using var scope = _webApplicationFactory.Services.CreateScope();
            RateMovieDBContext db = scope.ServiceProvider.GetRequiredService<RateMovieDBContext>();
            await action(db);
        }

        private protected async Task<IntegrationTestUser> UseUserGeneratorInDBContext()
        {
            var user = UserBuilder.Build();
            user.Password = new PasswordHasherBcrypt().HashPassword(user.Password);

            await UseRateMovieDBContext(async context =>
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            });

            var token = _tokenGenerator.GenerateToken(user);

            var userGenerated = new IntegrationTestUser(user.Id, user.Name, user.Email, user.Password, user.Role, token);

            return userGenerated;
        }

        private void AddJwtAuthHeader(string? token = null)
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
            AddJwtAuthHeader(token);
            AddAcceptLanguageCultureHeader(culture);

            var response = await _httpClient.PostAsJsonAsync(requestUri, payload);

            return response;
        }
    }
}
