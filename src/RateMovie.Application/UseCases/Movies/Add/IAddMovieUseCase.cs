using RateMovie.Communication.Requests.Movie;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.Add
{
    public interface IAddMovieUseCase
    {
        Task<ResponseMovieJson> Execute(RequestMovieJson req);
    }
}
