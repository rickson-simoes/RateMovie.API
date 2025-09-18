using RateMovie.Communication.Responses;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Domain.Resources.Success;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies.Delete
{
    internal class DeleteMovieUseCase : IDeleteMovieUseCase
    {
        private readonly IMovieDeleteOnlyRepository _movieDeleteOnlyRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public DeleteMovieUseCase(
            IMovieDeleteOnlyRepository movieDeleteOnlyRepository, 
            IUnitOfWorkRepository unitOfWorkRepository)
        {
            _movieDeleteOnlyRepository = movieDeleteOnlyRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        public async Task<ResponseMessageJson> Execute(int id)
        {
            var movie = await _movieDeleteOnlyRepository.GetById(id);

            if (movie is null)
                throw new MovieNotFoundException(ErrorMessagesResource.MOVIE_NOT_FOUND);

            _movieDeleteOnlyRepository.Delete(movie);
            await  _unitOfWorkRepository.Commit();

            ResponseMessageJson response = new()
            {
                Message = ResourceSuccessMessages.MOVIE_SUCCESSFULLY_DELETED
            };

            return response;
        }
    }
}
