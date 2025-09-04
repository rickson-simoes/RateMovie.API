using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Infraestructure.DataAccess;
using RateMovie.Infraestructure.Repositories.Movies;

namespace RateMovie.Infraestructure
{
    public static class DependencyInjectionInfra
    {
        public static void DependencyInjectionExtensionInfra(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped<IMovieWriteOnlyRepository, MovieWriteOnlyRepository>();

            var mySqlVersion = new MySqlServerVersion(new Version(8, 0, 42));
            var connectionString = config.GetConnectionString("ConnectionDBMySql");

            service.AddDbContext<RateMovieDBContext>(opt =>
            {
                opt
                .UseMySql(connectionString, mySqlVersion)
                .LogTo(Console.WriteLine, LogLevel.Information);
            });
        }
    }
}
