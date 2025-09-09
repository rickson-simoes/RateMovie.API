using RateMovie.Application.UseCases.MovieMapper;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Exception.RateMovieExceptions;

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
            ValidationHandler(request);

            ResponseMovieJson response = request.ToResponseMovieJson();
            Movie movieEntity = response.ToMovieEntity();

            await _movieRepository.Add(movieEntity);
            await _unitOfWork.Commit();

            return response;
        }

        private void ValidationHandler(RequestMovieJson request)
        {
            List<string> errors = [];

            // Nullish
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add("Name can't be null");
            }

            // Length
            if (request.Name.Length > 90)
            {
                errors.Add("Movie name must not exceed 90 characters.");
            }

            if (request.Comment is not null && request.Comment.Length > 700)
            {
                errors.Add("Movie comment must not exceed 700 characters.");
            }

            // Stars 1 to 5;
            if (request.Stars < 1 || request.Stars > 5)
            {
                errors.Add("Stars must be between 1 and 5");
            }

            // Exception
            if (errors.Count != 0)
            {
                throw new ValidationHandlerException(errors);
            }
        }
    }
}
