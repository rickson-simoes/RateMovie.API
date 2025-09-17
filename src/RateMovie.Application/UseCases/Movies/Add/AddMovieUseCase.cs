using RateMovie.Application.MovieMapper;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;

namespace RateMovie.Application.UseCases.Movies.Add
{
    internal class AddMovieUseCase : IAddMovieUseCase
    {
        private readonly IMovieWriteOnlyRepository _movieRepository;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public AddMovieUseCase(IMovieWriteOnlyRepository movieRepository, IUnitOfWorkRepository unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseMovieJson> Execute(RequestMovieJson request)
        {
            new MoviesValidatorHandler().RequestMovie(request);

            ResponseMovieJson response = request.ToResponseMovieJson();
            Movie movieEntity = response.ToMovieEntity();

            await _movieRepository.Add(movieEntity);
            await _unitOfWork.Commit();

            return response;
        }
    }
}
