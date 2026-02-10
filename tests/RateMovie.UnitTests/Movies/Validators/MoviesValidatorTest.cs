using FluentValidation.Results;
using RateMovie.Application.UseCases.Movies;
using RateMovie.CommonUtilities.Requests;
using RateMovie.Communication.Requests.Movie;
using RateMovie.Exception;
using Shouldly;

namespace RateMovie.UnitTests.Movies.Validators
{
    public class MoviesValidatorTest
    {
        [Fact]
        public void Success()
        {
            var request = RequestMovieJsonBuilder.Build();
            var validator = Validation(request);

            validator.IsValid.ShouldBeTrue();
            validator.Errors.ShouldBeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Should_Fail_When_Movie_Name_Is_Null_Or_Empty(string movieName)
        {
            var request = RequestMovieJsonBuilder.Build();
            request.Name = movieName;

            var validator = Validation(request);

            validator.IsValid.ShouldBeFalse();
            validator
                .Errors
                .ShouldHaveSingleItem()
                .ErrorMessage
                .ShouldBe(ErrorMessagesResource.MOVIE_NAME_CANT_BE_NULL);
        }

        [Fact]
        public void Should_Fail_When_Movie_Name_Is_Above_90_Characters()
        {
            var request = RequestMovieJsonBuilder.Build();
            request.Name = string.Create(91, 'A', (span, ch) => span.Fill(ch));

            var validator = Validation(request);

            validator.IsValid.ShouldBeFalse();
            validator
                .Errors
                .ShouldHaveSingleItem()
                .ErrorMessage
                .ShouldBe(ErrorMessagesResource.MOVIE_NAME_MAX_CHARACTER_LENGTH);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Should_Succeed_When_Comment_Is_Null_Or_Empty(string comment)
        {
            var request = RequestMovieJsonBuilder.Build();
            request.Comment = comment;

            var validator = Validation(request);

            validator.IsValid.ShouldBeTrue();
            validator.Errors.ShouldBeEmpty();
        }

        [Fact]
        public void Should_Fail_If_Comment_Exceeds_700_Characters()
        {
            var request = RequestMovieJsonBuilder.Build();
            request.Comment = string.Create(701, 'A', (span, ch) => span.Fill(ch));

            var validator = Validation(request);

            validator.IsValid.ShouldBeFalse();
            validator
                .Errors
                .ShouldHaveSingleItem()
                .ErrorMessage
                .ShouldBe(ErrorMessagesResource.MOVIE_COMMENT_MAX_CHARACTER_LENGTH);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        [InlineData(9)]
        public void Should_Fail_When_Stars_Are_Out_Of_Range(byte stars)
        {
            var request = RequestMovieJsonBuilder.Build();
            request.Stars = stars;

            var validator = Validation(request);

            validator.IsValid.ShouldBeFalse();
            validator
                .Errors
                .ShouldHaveSingleItem()
                .ErrorMessage
                .ShouldBe(ErrorMessagesResource.MOVIE_STARS_BETWEEN_RANGE);
        }

        [Fact]
        public void Should_Fail_When_Genre_Is_Invalid()
        {
            var request = RequestMovieJsonBuilder.Build();
            request.Genre = (Communication.Enum.MovieGenre)8;

            var validator = Validation(request);

            validator.IsValid.ShouldBeFalse();
            validator
                .Errors
                .ShouldHaveSingleItem()
                .ErrorMessage
                .ShouldBe(ErrorMessagesResource.MOVIE_GENRE_INVALID);
        }

        private ValidationResult Validation(RequestMovieJson request)
        {
            return new MoviesValidator().Validate(request);
        }
    }
}
