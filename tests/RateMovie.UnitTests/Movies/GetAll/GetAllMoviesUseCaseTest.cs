using RateMovie.Application.UseCases.Movies.GetAll;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Repositories.Movies;
using RateMovie.CommonUtilities.Services;
using RateMovie.Domain.Entities;
using Shouldly;

namespace RateMovie.UnitTests.Movies.GetAll
{
    public class GetAllMoviesUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user, 3);

            var execute = await useCase.Execute();

            execute.Movies.ShouldNotBeEmpty();
            execute.Movies.ForEach(movie => movie.Stars.ShouldBeInRange((byte)1, (byte)5));
            execute.Movies.ForEach(movie => movie.Name.ShouldNotBeEmpty());
            execute.Movies.ForEach(movie => Enum.IsDefined(typeof(Communication.Enum.MovieGenre), movie.Genre));
        }

        [Fact]
        public async Task Should_Be_Empty_If_No_Movies()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = await useCase.Execute();

            execute.Movies.ShouldBeEmpty();
        }


        private GetAllMoviesUseCase CreateUseCase(User user, int? movieQuantity = null)
        {
            var movieReadOnlyRepository = new MovieReadOnlyRepositoryBuilder().GetAll(user, movieQuantity).Build();
            var loggedUser = LoggedUserBuilder.Build(user);

            return new GetAllMoviesUseCase(movieReadOnlyRepository, loggedUser);
        }
    }
}
