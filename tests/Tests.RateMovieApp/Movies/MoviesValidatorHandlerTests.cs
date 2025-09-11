using RateMovie.Application.UseCases.Movies;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;
using Tests.CommonUtilities.BogusMovieValidator;

namespace Tests.RateMovieApp.Movies
{
    public class MoviesValidatorHandlerTests
    {
        private readonly MoviesValidatorHandler _validator = new();

        [Fact]
        public void Success_Movie_Data()
        {
            var request = new RequestMovieDataBuilder().Build();

            var requestException = Record.Exception(() => _validator.RequestMovie(request));

            Assert.Null(requestException);
        }

        [Fact]
        public void Success_Comment_Null()
        {
            var request = new RequestMovieDataBuilder().Build();
            request.Comment = null;

            var requestException = Record.Exception(() => _validator.RequestMovie(request));

            Assert.Null(requestException);
            Assert.Null(request.Comment);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Fail_When_Name_Is_Null_Or_Empty(string? name)
        {
            var request = new RequestMovieDataBuilder().Build();
            request.Name = name;

            var ex = Assert.Throws<ValidationHandlerException>(() => _validator.RequestMovie(request));
            Assert.Contains(ErrorMessagesResource.NAME_CANT_BE_NULL, ex.GetErrors());
        }

        [Fact]
        public void Fail_When_Name_Is_Too_Long()
        {
            var request = new RequestMovieDataBuilder().Build();
            request.Name = new string('T', 91);

            var ex = Assert.Throws<ValidationHandlerException>(() => _validator.RequestMovie(request));
            Assert.Contains(ErrorMessagesResource.MOVIE_NAME_MAX_CHARACTER_LENGTH, ex.GetErrors());
        }

        [Fact]
        public void Fail_When_Comment_Is_Too_Long()
        {
            var request = new RequestMovieDataBuilder().Build();
            request.Comment = new string('T', 701);

            var ex = Assert.Throws<ValidationHandlerException>(() => _validator.RequestMovie(request));
            Assert.Contains(ErrorMessagesResource.MOVIE_COMMENT_MAX_CHARACTER_LENGTH, ex.GetErrors());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void Fail_When_Stars_Are_Out_Of_Range(byte invalidStars)
        {
            var request = new RequestMovieDataBuilder().Build();
            request.Stars = invalidStars;

            var ex = Assert.Throws<ValidationHandlerException>(() => _validator.RequestMovie(request));
            Assert.Contains(ErrorMessagesResource.MOVIE_STARS_BETWEEN_RANGE, ex.GetErrors());
        }
    }
}
