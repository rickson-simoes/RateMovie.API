using Microsoft.Extensions.DependencyInjection;
using RateMovie.Application.UseCases.Movies.Add;
using RateMovie.Application.UseCases.Movies.Delete;
using RateMovie.Application.UseCases.Movies.GetAll;
using RateMovie.Application.UseCases.Movies.Update;
using RateMovie.Application.UseCases.Reports.GenerateMoviesExcel;

namespace RateMovie.Application
{
    public static class DependencyInjectionApplication
    {
        public static void DependencyInjectionExtensionApp(this IServiceCollection service)
        {
            service.AddScoped<IAddMovieUseCase, AddMovieUseCase>();
            service.AddScoped<IGetAllMoviesUseCase, GetAllMoviesUseCase>();
            service.AddScoped<IUpdateMovieUseCase, UpdateMovieUseCase>();
            service.AddScoped<IDeleteMovieUseCase, DeleteMovieUseCase>();
            service.AddScoped<IGenerateMoviesExcelUseCase, GenerateMoviesExcelUseCase>();
        }
    }
}
