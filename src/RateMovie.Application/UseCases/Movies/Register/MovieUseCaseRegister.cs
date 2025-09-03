using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Infraestructure.Repositories.Movies;
using RateMovie.Domain.Entities;

namespace RateMovie.Application.UseCases.Movies.Register
{
    internal class MovieUseCaseRegister : IMovieUseCaseRegister
    {
        public async Task<ResponseMovieJson> Execute(RequestMovieJson req)
        {
            var movieRepository = new MovieWriteOnlyRepository();

            ResponseMovieJson movieRequest = new()
            {
                Name = req.Name,
                Comment = req.Comment,
                Stars = req.Stars,
            };

            var movie = new Movie
            {
                Name = movieRequest.Name,
                Comment = movieRequest.Comment,
                Stars = movieRequest.Stars
            };

            await movieRepository.Register(movie);            

            return movieRequest;
        }
    }
}
