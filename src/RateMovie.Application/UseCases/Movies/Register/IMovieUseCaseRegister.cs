using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movies.Register
{
    public interface IMovieUseCaseRegister
    {
        Task<ResponseMovieJson> Execute(RequestMovieJson req);
    }
}
