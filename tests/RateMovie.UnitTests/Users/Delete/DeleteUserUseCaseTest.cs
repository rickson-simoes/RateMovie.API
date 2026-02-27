using RateMovie.Application.UseCases.Users.Delete;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Repositories.UnitOfWork;
using RateMovie.CommonUtilities.Repositories.Users;
using RateMovie.CommonUtilities.Services;
using RateMovie.Domain.Entities;
using Shouldly;

namespace RateMovie.UnitTests.Users.Delete
{
    public class DeleteUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = async () => await useCase.Execute();

            await execute.ShouldNotThrowAsync();

        }

        private DeleteUserUseCase CreateUseCase(User user)
        {
            var unitOfWork = UnitOfWorkBuilder.Build();
            var deleteOnlyRepository = UserDeleteOnlyRepositoryBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);

            return new DeleteUserUseCase(unitOfWork, deleteOnlyRepository, loggedUser);
        }
    }
}
