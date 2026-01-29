using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RateMovie.Api;
using RateMovie.Infrastructure.DataAccess;

namespace RateMovie.IntegrationTests.CustomFactory
{
    public class CustomWebApplicationFactorySQLite : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(serviceDescriptor => 
                    serviceDescriptor.ServiceType == typeof(DbContextOptions<RateMovieDBContext>));

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                var connection = new SqliteConnection("Filename=:memory:");
                connection.Open();

                services.AddDbContext<RateMovieDBContext>((container, options) =>
                {
                    options.UseSqlite(connection);
                });
            });
        }
    }
}
