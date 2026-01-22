using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Services;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies.Delete
{
    internal class DeleteMovieUseCase(
        IMovieDeleteOnlyRepository _movieDeleteRepository,
        IMovieUpdateOnlyRepository _movieUpdateRepository,
        IUnitOfWorkRepository _unitOfWorkRepository,
        ILoggedUser _loggedUser) : IDeleteMovieUseCase
    {
        public async Task Execute(int id)
        {
            var loggedUser = await _loggedUser.Get();
            var movie = await _movieUpdateRepository.GetById(id, loggedUser.Id);

            if (movie is null)
                throw new MovieNotFoundException(ErrorMessagesResource.MOVIE_NOT_FOUND);

            _movieDeleteRepository.Delete(movie);

            await  _unitOfWorkRepository.Commit();
        }
    }
}
