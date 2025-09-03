using Microsoft.Extensions.DependencyInjection;
using RateMovie.Application.UseCases.Movies.Register;

namespace RateMovie.Application
{
    public static class DependencyInjectionApplication
    {
        public static void DependencyInjectionExtensionApp(this IServiceCollection service)
        {
            service.AddScoped<IMovieUseCaseRegister, MovieUseCaseRegister>();
        }
    }
}
