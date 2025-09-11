using RateMovie.Communication.Requests;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Application.UseCases.Movies
{
    public class MoviesValidatorHandler
    {
        public void RequestMovie(RequestMovieJson request)
        {
            List<string> errors = [];

            // Nullish
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                errors.Add(ErrorMessagesResource.NAME_CANT_BE_NULL);
            }

            // Length
            if (request.Name?.Length > 90)
            {
                errors.Add(ErrorMessagesResource.MOVIE_NAME_MAX_CHARACTER_LENGTH);
            }

            if (request.Comment is not null && request.Comment.Length > 700)
            {
                errors.Add(ErrorMessagesResource.MOVIE_COMMENT_MAX_CHARACTER_LENGTH);
            }

            // Stars 1 to 5;
            if (request.Stars < 1 || request.Stars > 5)
            {
                errors.Add(ErrorMessagesResource.MOVIE_STARS_BETWEEN_RANGE);
            }

            // Exception
            if (errors.Count != 0)
            {
                throw new ValidationHandlerException(errors);
            }
        }
    }
}
