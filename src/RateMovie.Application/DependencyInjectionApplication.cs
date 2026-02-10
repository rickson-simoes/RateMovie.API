using Microsoft.Extensions.DependencyInjection;
using RateMovie.Application.UseCases.Login;
using RateMovie.Application.UseCases.Movies.Add;
using RateMovie.Application.UseCases.Movies.Delete;
using RateMovie.Application.UseCases.Movies.GetAll;
using RateMovie.Application.UseCases.Movies.GetById;
using RateMovie.Application.UseCases.Movies.Update;
using RateMovie.Application.UseCases.Reports.GenerateMoviesExcel;
using RateMovie.Application.UseCases.Reports.GenerateMoviesPdf;
using RateMovie.Application.UseCases.Users.Add;
using RateMovie.Application.UseCases.Users.Delete;

namespace RateMovie.Application
{
    public static class DependencyInjectionApplication
    {
        public static void DependencyInjectionExtensionApp(this IServiceCollection service)
        {
            service.AddScoped<ILoginUseCase, LoginUseCase>();

            service.AddScoped<IAddUserUseCase, AddUserUseCase>();
            service.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();

            service.AddScoped<IAddMovieUseCase, AddMovieUseCase>();
            service.AddScoped<IGetAllMoviesUseCase, GetAllMoviesUseCase>();
            service.AddScoped<IUpdateMovieUseCase, UpdateMovieUseCase>();
            service.AddScoped<IDeleteMovieUseCase, DeleteMovieUseCase>();
            service.AddScoped<IGetMovieByIdUseCase, GetMovieByIdUseCase>();
            service.AddScoped<IGenerateMoviesExcelUseCase, GenerateMoviesExcelUseCase>();
            service.AddScoped<IGenerateMoviesPdfUseCase, GenerateMoviesPdfUseCase>();
        }
    }
}
