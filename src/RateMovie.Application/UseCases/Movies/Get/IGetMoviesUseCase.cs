using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.Get
{
    public interface IGetMoviesUseCase
    {
        Task<ResponseListShortMovieJson> Execute();
    }
}
