using RateMovie.Application.UseCases.Users.GetAllData;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Services;
using RateMovie.Domain.Entities;
using Shouldly;

namespace RateMovie.UnitTests.Users.GetAllData
{
    public class GetAllDataUseCaseTest
    {
        [Fact]
        public async void Success()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = await useCase.Execute();

            execute.name.ShouldBe(user.Name);
            execute.email.ShouldBe(user.Email);
            execute.role.ShouldBe((Communication.Enum.UserRole)user.Role);
        }

        private GetAllUserDataUseCase CreateUseCase(User user)
        {
            var loggedUser = LoggedUserBuilder.Build(user);

            return new GetAllUserDataUseCase(loggedUser);
        }
    }
}
