using RateMovie.Application.Mapper;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Services;

namespace RateMovie.Application.UseCases.Movies.GetAll
{
    internal class GetAllMoviesUseCase(
        IMovieReadOnlyRepository _movieRepository,
        ILoggedUser _loggedUser) : IGetAllMoviesUseCase
    {
        public async Task<ResponseListShortMovieJson> Execute()
        {
            var user = await _loggedUser.Get();
            var movies = await _movieRepository.GetAll(user.Id);

            var moviesResponseListShort = movies.Select(movie => movie.ToResponseShortMovieJson()).ToList();

            ResponseListShortMovieJson moviesList = new ResponseListShortMovieJson()
            {
                Movies = moviesResponseListShort
            };

            return moviesList;
        }
    }
}
