using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Infraestructure.DataAccess;
using RateMovie.Infraestructure.Repositories.Movies;
using RateMovie.Infraestructure.UnitOfWork;

namespace RateMovie.Infraestructure
{
    public static class DependencyInjectionInfra
    {
        public static void DependencyInjectionExtensionInfra(this IServiceCollection service, IConfiguration config)
        {
            DependencyInjectionDbContext(service, config);
            DependencyInjectionScoped(service);
        }

        private static void DependencyInjectionScoped(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            service.AddScoped<IMovieWriteOnlyRepository, MovieRepository>();
            service.AddScoped<IMovieReadOnlyRepository, MovieRepository>();
            service.AddScoped<IMovieUpdateOnlyRepository, MovieRepository>();
        }

        private static void DependencyInjectionDbContext(IServiceCollection service, IConfiguration config)
        {
            var version = new Version(8, 0, 42);
            var mySqlVersion = new MySqlServerVersion(version);
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
