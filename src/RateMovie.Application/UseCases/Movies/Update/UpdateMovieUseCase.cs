using RateMovie.Application.Mapper;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies.Update
{
    internal class UpdateMovieUseCase : IUpdateMovieUseCase
    {
        private readonly IMovieUpdateOnlyRepository _movieRepository;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public UpdateMovieUseCase(IMovieUpdateOnlyRepository movieRepository, IUnitOfWorkRepository unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseMovieJson> Execute(int id, RequestMovieJson req)
        {
            new MoviesValidatorHandler().RequestMovie(req);

            Movie? movie = await _movieRepository.GetById(id);

            if (movie is null)
                throw new MovieNotFoundException(ErrorMessagesResource.MOVIE_NOT_FOUND);

            movie.GetRequestMovieData(req);

            _movieRepository.Update(movie);
            await _unitOfWork.Commit();

            return req.ToResponseMovieJson();
        }
    }
}
