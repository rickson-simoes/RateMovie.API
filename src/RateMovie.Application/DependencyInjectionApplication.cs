using Microsoft.Extensions.DependencyInjection;
using RateMovie.Application.UseCases.Movies.Add;
using RateMovie.Application.UseCases.Movies.GetAll;

namespace RateMovie.Application
{
    public static class DependencyInjectionApplication
    {
        public static void DependencyInjectionExtensionApp(this IServiceCollection service)
        {
            service.AddScoped<IAddMovieUseCase, AddMovieUseCase>();
            service.AddScoped<IGetAllMoviesUseCase, GetAllMoviesUseCase>();
        }
    }
}
