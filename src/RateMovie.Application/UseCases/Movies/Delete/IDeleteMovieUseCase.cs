using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.Delete
{
    public interface IDeleteMovieUseCase
    {
        Task Execute(int id);
    }
}
