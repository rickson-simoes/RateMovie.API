using RateMovie.Application.Mapper;
using RateMovie.Communication.Requests.Movie;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Services;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies.Add
{
    internal class AddMovieUseCase(
        IMovieWriteOnlyRepository _movieRepository,
        IUnitOfWorkRepository _unitOfWork,
        ILoggedUser _loggedUser) : IAddMovieUseCase
    {
        public async Task<ResponseMovieJson> Execute(RequestMovieJson request)
        {
            var loggedUser = await _loggedUser.Get();

            RequestValidator(request);

            Movie movieEntity = request.ToMovieEntity(loggedUser.Id);

            await _movieRepository.Add(movieEntity);
            await _unitOfWork.Commit();

            ResponseMovieJson response = movieEntity.ToResponseMovieJson();

            return response;
        }

        public void RequestValidator(RequestMovieJson request)
        {
            var validate = new MoviesValidator().Validate(request);

            if (validate.IsValid is false)
            {
                var errMsgs = validate.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ValidationHandlerException(errMsgs);
            }
        }
    }
}
