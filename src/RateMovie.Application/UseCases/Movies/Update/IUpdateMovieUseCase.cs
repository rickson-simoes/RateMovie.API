using RateMovie.Communication.Requests.Movie;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.Update
{
    public interface IUpdateMovieUseCase
    {
        Task<ResponseMovieJson> Execute(int id, RequestMovieJson req);
    }
}
