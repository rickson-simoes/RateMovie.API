using RateMovie.Communication.Responses.Movie;

namespace RateMovie.Application.UseCases.Movies.GetAll
{
    public interface IGetAllMoviesUseCase
    {
        Task<ResponseListShortMovieJson> Execute();
    }
}
