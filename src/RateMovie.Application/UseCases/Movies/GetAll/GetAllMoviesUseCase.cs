using RateMovie.Application.Mapper;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.Application.UseCases.Movies.GetAll
{
    internal class GetAllMoviesUseCase : IGetAllMoviesUseCase
    {
        private readonly IMovieReadOnlyRepository _movieRepository;

        public GetAllMoviesUseCase(IMovieReadOnlyRepository movieRepository)
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
