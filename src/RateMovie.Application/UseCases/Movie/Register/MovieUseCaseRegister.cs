using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;

namespace RateMovie.Application.UseCases.Movie.Register
{
    internal class MovieUseCaseRegister : IMovieUseCaseRegister
    {
        public ResponseMovieJson Execute(RequestMovieJson req)
        {
            var movie = req;

            var response = new ResponseMovieJson
            {
                Id = 1,
                Name = movie.Name,
                Comment = movie.Comment,
                Stars = movie.Stars,
            };

            return response;
        }
    }
}
