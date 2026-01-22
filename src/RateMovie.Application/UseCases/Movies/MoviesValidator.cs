using FluentValidation;
using RateMovie.Communication.Requests;
using RateMovie.Exception;

namespace RateMovie.Application.UseCases.Movies
{
    internal class MoviesValidator : AbstractValidator<RequestMovieJson>
    {
        public MoviesValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage(ErrorMessagesResource.MOVIE_NAME_CANT_BE_NULL)
                .MaximumLength(90)
                .When(m => string.IsNullOrWhiteSpace(m.Name) is false, ApplyConditionTo.CurrentValidator)
                .WithMessage(ErrorMessagesResource.MOVIE_NAME_MAX_CHARACTER_LENGTH);

            RuleFor(m => m.Comment)
                .MaximumLength(700)
                .WithMessage(ErrorMessagesResource.MOVIE_COMMENT_MAX_CHARACTER_LENGTH);

            RuleFor(m => m.Stars)
                .InclusiveBetween((byte)1, (byte)5)
                .WithMessage(ErrorMessagesResource.MOVIE_STARS_BETWEEN_RANGE);

            RuleFor(m => m.Genre)
                .IsInEnum()
                .WithMessage(ErrorMessagesResource.MOVIE_GENRE_INVALID);
        }
    }
}
