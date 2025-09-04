using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.Application.UseCases.Movies.Register
{
    internal class RegisterMovieUseCase : IRegisterMovieUseCase
    {
        private readonly IMovieWriteOnlyRepository _movieRepository;
        public RegisterMovieUseCase(IMovieWriteOnlyRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ResponseMovieJson> Execute(RequestMovieJson req)
        {
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

            await _movieRepository.Register(movie);            

            return movieRequest;
        }
    }
}
