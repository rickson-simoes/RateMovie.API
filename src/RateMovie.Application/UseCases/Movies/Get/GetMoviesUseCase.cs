using RateMovie.Communication.Responses;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.Application.UseCases.Movies.Get
{
    internal class GetMoviesUseCase : IGetMoviesUseCase
    {
        private readonly IMovieReadOnlyRepository _movieRepository;
        public GetMoviesUseCase(IMovieReadOnlyRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<ResponseListShortMovieJson> Execute()
        {
            ResponseListShortMovieJson moviesList = new ResponseListShortMovieJson();

            var movies = await _movieRepository.Get();

            var moviesResponseListShort = movies.Select(movie => new ResponseShortMovieJson
            {
                Id = movie.Id,
                Name = movie.Name,
                Stars = movie.Stars,
            });

            moviesList.Movies.AddRange(moviesResponseListShort);

            return moviesList;
        }
    }
}
