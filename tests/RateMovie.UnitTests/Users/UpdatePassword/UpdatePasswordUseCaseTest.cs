using RateMovie.Application.UseCases.Users.UpdatePassword;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Repositories.UnitOfWork;
using RateMovie.CommonUtilities.Repositories.Users;
using RateMovie.CommonUtilities.Requests;
using RateMovie.CommonUtilities.Security.PasswordHasher;
using RateMovie.CommonUtilities.Services;
using RateMovie.Domain.Entities;
using Shouldly;

namespace RateMovie.UnitTests.Users.UpdatePassword
{
    public class UpdatePasswordUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestUpdateUserPasswordJsonBuilder.Build();
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = async () => await useCase.Execute(request);

            await execute.ShouldNotThrowAsync();
        }

        // Note: Password validation already being tested.

        private UpdateUserPasswordUseCase CreateUseCase(User user)
        {
            var unitOfWork = UnitOfWorkBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);
            var userWriteOnly = UserWriteOnlyRepositoryBuilder.Build();
            var passwordHasher = new PasswordHasherBuilder().HashPassword().Build();

            return new UpdateUserPasswordUseCase(unitOfWork, loggedUser, passwordHasher, userWriteOnly);
        }
    }
}
