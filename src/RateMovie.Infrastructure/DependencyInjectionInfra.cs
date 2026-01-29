using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Domain.Security.PasswordHasher;
using RateMovie.Domain.Security.TokenGenerator;
using RateMovie.Domain.Services;
using RateMovie.Infrastructure.DataAccess;
using RateMovie.Infrastructure.Repositories.Movies;
using RateMovie.Infrastructure.Repositories.Users;
using RateMovie.Infrastructure.Security.PasswordHasher;
using RateMovie.Infrastructure.Security.TokenGenerator;
using RateMovie.Infrastructure.Services.LoggedUser;
using RateMovie.Infrastructure.UnitOfWork;

namespace RateMovie.Infrastructure
{
    public static class DependencyInjectionInfra
    {
        public static void DependencyInjectionExtensionInfra(this IServiceCollection service, IConfiguration config)
        {
            DependencyInjectionDbContext(service, config);
            DependencyInjectionScoped(service, config);
        }

        private static void DependencyInjectionScoped(IServiceCollection service, IConfiguration config)
        {
            service.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            service.AddScoped<IPasswordHasher, PasswordHasherBcrypt>();
        
            var signingKey = config.GetValue<string>("TokenSettings:JWT:SigningKey")!;
            var minutesToExpire = config.GetValue<int>("TokenSettings:JWT:MinutesToExpire");
            service.AddScoped<ITokenGenerator>(_ => new TokenGeneratorJWT(signingKey, minutesToExpire));

            service.AddScoped<ILoggedUser, LoggedUser>();

            service.AddScoped<IMovieWriteOnlyRepository, MovieRepository>();
            service.AddScoped<IMovieReadOnlyRepository, MovieRepository>();
            service.AddScoped<IMovieUpdateOnlyRepository, MovieRepository>();
            service.AddScoped<IMovieDeleteOnlyRepository, MovieRepository>();

            service.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            service.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }

        private static void DependencyInjectionDbContext(IServiceCollection service, IConfiguration config)
        {
            var testEnvironemnt = config.GetValue<bool>("TestEnvironment");
            if (testEnvironemnt is false)
            {
                var connectionString = config.GetConnectionString("ConnectionDBMySql");
                var serverVersion = ServerVersion.AutoDetect(connectionString);

                service.AddDbContext<RateMovieDBContext>(opt =>
                {
                    opt
                    .UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information);
                });
            }
        }
    }
}
