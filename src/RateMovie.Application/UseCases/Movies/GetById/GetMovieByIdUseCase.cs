using RateMovie.Application.Mapper;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Services;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies.GetById
{
    public class GetMovieByIdUseCase(
        IMovieReadOnlyRepository _movieReadOnlyRepository, 
        ILoggedUser _loggedUser) : IGetMovieByIdUseCase
    {
        public async Task<ResponseMovieJson> Execute(int id)
        {
            var user = await _loggedUser.Get();
            var movie = await _movieReadOnlyRepository.GetById(id, user.Id);

            if (movie is null)
            {
                throw new MovieNotFoundException(ErrorMessagesResource.MOVIE_NOT_FOUND);
            }

            var response = movie.ToResponseMovieJson();

            return response;
        }
    }
}
