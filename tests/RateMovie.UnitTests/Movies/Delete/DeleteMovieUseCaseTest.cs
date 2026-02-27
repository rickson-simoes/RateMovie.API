using RateMovie.Application.UseCases.Movies.Delete;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Repositories.Movies;
using RateMovie.CommonUtilities.Repositories.UnitOfWork;
using RateMovie.CommonUtilities.Services;
using RateMovie.Domain.Entities;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;
using Shouldly;
using System.Net;

namespace RateMovie.UnitTests.Movies.Delete
{
    public class DeleteMovieUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var movie = MovieBuilder.Build(user);
            var useCase = CreateUseCase(user, movie);

            var execute = async () => await useCase.Execute(movie.Id);

            await execute.ShouldNotThrowAsync();
        }

        [Fact]
        public async Task Should_Fail_If_Movie_Is_Null()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = async () => await useCase.Execute(0);

            var testResponse = await execute.ShouldThrowAsync<MovieNotFoundException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.NotFound);
            testResponse.GetErrors().ShouldHaveSingleItem().ShouldBe(ErrorMessagesResource.MOVIE_NOT_FOUND);
        }


        private DeleteMovieUseCase CreateUseCase(User user, Movie? movie = null)
        {
            var movieDeleteOnlyRepository = MovieDeleteOnlyRepository.Build();
            var movieUpdateOnlyRepository = new MovieUpdateOnlyRepository();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);

            if (movie is not null)
            {
                movieUpdateOnlyRepository.GetById(movie);
            } 

            return new DeleteMovieUseCase(
                movieDeleteOnlyRepository, 
                movieUpdateOnlyRepository.Build(), 
                unitOfWork, 
                loggedUser);
        }
    }
}
