using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.GetById
{
    public interface IGetMovieByIdUseCase
    {
        Task<ResponseMovieJson> Execute(int id);
    }
}
