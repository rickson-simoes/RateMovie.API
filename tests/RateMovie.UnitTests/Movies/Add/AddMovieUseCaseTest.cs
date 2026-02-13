using RateMovie.Application.UseCases.Movies.Add;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Repositories.Movies;
using RateMovie.CommonUtilities.Repositories.UnitOfWork;
using RateMovie.CommonUtilities.Requests;
using RateMovie.CommonUtilities.Services;
using RateMovie.Domain.Entities;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;
using Shouldly;
using System.Net;

namespace RateMovie.UnitTests.Movies.Add
{
    public class AddMovieUseCaseTest
    {
        [Fact]
        public async void Success()
        {
            var user = UserBuilder.Build();
            var movieRequest = RequestMovieJsonBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = await useCase.Execute(movieRequest);

            execute.Name.ShouldBe(movieRequest.Name);
            execute.Comment.ShouldBe(movieRequest.Comment);
            execute.Genre.ShouldBe(movieRequest.Genre);
            execute.Stars.ShouldBe(movieRequest.Stars);
            execute.CreatedAt.ShouldBeOfType<DateTime>();
        }

        [Fact]
        public async void Should_Fail_When_Movie_Name_Is_Null()
        {
            var user = UserBuilder.Build();
            var movieRequest = RequestMovieJsonBuilder.Build();
            movieRequest.Name = string.Empty;

            var useCase = CreateUseCase(user);
            var execute = async () => await useCase.Execute(movieRequest);

            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().ShouldHaveSingleItem().ShouldBe(ErrorMessagesResource.MOVIE_NAME_CANT_BE_NULL);
        }

        [Fact]
        public async void Should_Fail_When_Movie_Name_Is_Above_90_Characters()
        {
            var user = UserBuilder.Build();
            var movieRequest = RequestMovieJsonBuilder.Build();
            movieRequest.Name = string.Create(91, 'A', (span, a) => span.Fill(a));

            var useCase = CreateUseCase(user);
            var execute = async () => await useCase.Execute(movieRequest);

            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().ShouldHaveSingleItem().ShouldBe(ErrorMessagesResource.MOVIE_NAME_MAX_CHARACTER_LENGTH);
        }

        [Fact]
        public async void Should_Fail_When_Movie_Comment_Is_Above_700_Characters()
        {
            var user = UserBuilder.Build();
            var movieRequest = RequestMovieJsonBuilder.Build();
            movieRequest.Comment = string.Create(701, 'A', (span, a) => span.Fill(a));

            var useCase = CreateUseCase(user);
            var execute = async () => await useCase.Execute(movieRequest);

            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().ShouldHaveSingleItem().ShouldBe(ErrorMessagesResource.MOVIE_COMMENT_MAX_CHARACTER_LENGTH);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public async void Should_Fail_When_Movie_Stars_Is_Out_Of_Range(byte stars)
        {
            var user = UserBuilder.Build();
            var movieRequest = RequestMovieJsonBuilder.Build();
            movieRequest.Stars = stars;

            var useCase = CreateUseCase(user);
            var execute = async () => await useCase.Execute(movieRequest);

            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().ShouldHaveSingleItem().ShouldBe(ErrorMessagesResource.MOVIE_STARS_BETWEEN_RANGE);
        }

        [Fact]
        public async void Should_Fail_When_Movie_Genre_Is_Invalid()
        {
            var user = UserBuilder.Build();
            var movieRequest = RequestMovieJsonBuilder.Build();
            movieRequest.Genre = (Communication.Enum.MovieGenre)6;

            var useCase = CreateUseCase(user);
            var execute = async () => await useCase.Execute(movieRequest);

            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().ShouldHaveSingleItem().ShouldBe(ErrorMessagesResource.MOVIE_GENRE_INVALID);
        }

        private AddMovieUseCase CreateUseCase(User user)
        {
            var movieWriteOnlyRepository = MovieWriteOnlyRepositoryBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);

            return new AddMovieUseCase(movieWriteOnlyRepository, unitOfWork, loggedUser);
        }
    }
}
