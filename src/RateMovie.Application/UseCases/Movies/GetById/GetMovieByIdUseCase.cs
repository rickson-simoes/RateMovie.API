using RateMovie.Application.MovieMapper;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies.GetById
{
    public class GetMovieByIdUseCase : IGetMovieByIdUseCase
    {
        private readonly IMovieReadOnlyRepository _movieReadOnlyRepository;

        public GetMovieByIdUseCase(IMovieReadOnlyRepository movieReadOnlyRepository)
        {
            _movieReadOnlyRepository = movieReadOnlyRepository;
        }
        public async Task<ResponseMovieJson> Execute(int id)
        {
            var movie = await _movieReadOnlyRepository.GetById(id);

            if (movie is null)
            {
                throw new MovieNotFoundException(ErrorMessagesResource.MOVIE_NOT_FOUND);
            }

            var response = movie.ToResponseMovieJson();

            return response;
        }
    }
}
