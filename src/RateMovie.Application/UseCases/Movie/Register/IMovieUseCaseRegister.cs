using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movie.Register
{
    public interface IMovieUseCaseRegister
    {
        ResponseMovieJson Execute(RequestMovieJson req);
    }
}
