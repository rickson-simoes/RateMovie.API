using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.Delete
{
    public interface IDeleteMovieUseCase
    {
        Task<ResponseMessageJson> Execute(int id);
    }
}
