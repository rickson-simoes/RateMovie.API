using RateMovie.Application.UseCases.Users.PatchVip;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Repositories.UnitOfWork;
using RateMovie.CommonUtilities.Repositories.Users;
using RateMovie.CommonUtilities.Security.TokenGenerator;
using RateMovie.CommonUtilities.Services;
using RateMovie.Domain.Entities;
using Shouldly;

namespace RateMovie.UnitTests.Users.PatchVip
{
    public class PatchVipUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = await useCase.Execute();

            execute.token.ShouldNotBeNull();
        }

        private PatchVipUserUseCase CreateUseCase(User user)
        {
            var unitOfWork = UnitOfWorkBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);
            var userWriteOnly = UserWriteOnlyRepositoryBuilder.Build();
            var tokenGenerator = TokenGeneratorBuilder.Build();

            return new PatchVipUserUseCase(unitOfWork, loggedUser, userWriteOnly, tokenGenerator);
        }
    }
}
