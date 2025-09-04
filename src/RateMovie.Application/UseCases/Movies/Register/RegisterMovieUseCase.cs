using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.Application.UseCases.Movies.Register
{
    internal class RegisterMovieUseCase : IRegisterMovieUseCase
    {
        private readonly IMovieWriteOnlyRepository _movieRepository;

        public RegisterMovieUseCase(IMovieWriteOnlyRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ResponseMovieJson> Execute(RequestMovieJson req)
        {
            ValidationHandler(req);

            ResponseMovieJson movieRequest = new()
            {
                Name = req.Name,
                Comment = req.Comment,
                Stars = req.Stars,
            };

            var movie = new Movie
            {
                Name = movieRequest.Name,
                Comment = movieRequest.Comment,
                Stars = movieRequest.Stars
            };

            await _movieRepository.Register(movie);            

            return movieRequest;
        }

        private void ValidationHandler(RequestMovieJson req)
        {
            List<string> errors = [];

            // Nullish
            if (string.IsNullOrWhiteSpace(req.Name))
            {
                errors.Add("Name can't be null");
            }

            // Length
            if (req.Name.Length > 90)
            {
                errors.Add("Movie name must not exceed 90 characters.");
            }

            if (req.Comment.Length > 700)
            {
                errors.Add("Movie comment must not exceed 700 characters.");
            }

            // Stars 1 to 5;
            if (req.Stars < 1 || req.Stars > 5)
            {
                errors.Add("Stars must be between 1 and 5");
            }

            // Exception
            if (errors.Count != 0)
            {
                string errs = string.Join(", ", errors);

                throw new ArgumentException(errs);
            }
        }
    }
}
