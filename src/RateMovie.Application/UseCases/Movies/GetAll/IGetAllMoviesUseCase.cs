using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.GetAll
{
    public interface IGetAllMoviesUseCase
    {
        Task<ResponseListShortMovieJson> Execute();
    }
}
