using RateMovie.Application.UseCases.MovieMapper;
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
            var movies = await _movieRepository.GetAll();

            var moviesResponseListShort = movies.Select(movie => movie.ToResponseShortMovieJson()).ToList();

            ResponseListShortMovieJson moviesList = new ResponseListShortMovieJson()
            {
                Movies = moviesResponseListShort
            };

            return moviesList;
        }
    }
}
