using RateMovie.Application.Mapper;
using RateMovie.Communication.Requests.Movie;
using RateMovie.Communication.Responses.Movie;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Services;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies.Update
{
    internal class UpdateMovieUseCase(
        IMovieUpdateOnlyRepository _movieUpdateRepository,
        IUnitOfWorkRepository _unitOfWork,
        ILoggedUser _loggedUser) : IUpdateMovieUseCase
    {
        public async Task<ResponseMovieJson> Execute(int id, RequestMovieJson request)
        {
            RequestValidator(request);

            var loggedUser = await _loggedUser.Get();
            Movie? movie = await _movieUpdateRepository.GetById(id, loggedUser.Id);

            if (movie is null)
                throw new MovieNotFoundException(ErrorMessagesResource.MOVIE_NOT_FOUND);

            movie.UpdateFromRequestMovieJson(request);
            _movieUpdateRepository.Update(movie);

            await _unitOfWork.Commit();

            return movie.ToResponseMovieJson();
        }

        private void RequestValidator(RequestMovieJson request)
        {
            var movieValidator = new MoviesValidator().Validate(request);

            if (movieValidator.IsValid is false)
            {
                var errMsgs = movieValidator.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ValidationHandlerException(errMsgs);
            }
        }
    }
}
