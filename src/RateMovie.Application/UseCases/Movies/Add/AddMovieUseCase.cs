using RateMovie.Application.Mapper;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Services;

namespace RateMovie.Application.UseCases.Movies.Add
{
    internal class AddMovieUseCase : IAddMovieUseCase
    {
        private readonly IMovieWriteOnlyRepository _movieRepository;
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly ILoggedUser _loggedUser;

        public AddMovieUseCase(
            IMovieWriteOnlyRepository movieRepository,
            IUnitOfWorkRepository unitOfWork,
            ILoggedUser loggedUser)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseMovieJson> Execute(RequestMovieJson request)
        {
            var loggedUser = await _loggedUser.Get();

            // @TODO: Remove this validator
            new MoviesValidatorHandler().RequestMovie(request);            

            Movie movieEntity = request.ToMovieEntity(loggedUser.Id);

            await _movieRepository.Add(movieEntity);
            await _unitOfWork.Commit();

            ResponseMovieJson response = request.ToResponseMovieJson();

            return response;
        }

        // @TODO: Create new validator with fluent validation for movies
    }
}
