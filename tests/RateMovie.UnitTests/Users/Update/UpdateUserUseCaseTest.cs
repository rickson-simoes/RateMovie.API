using RateMovie.Application.UseCases.Users.Update;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Repositories.UnitOfWork;
using RateMovie.CommonUtilities.Repositories.Users;
using RateMovie.CommonUtilities.Requests;
using RateMovie.CommonUtilities.Services;
using RateMovie.Communication.Requests.User;
using RateMovie.Domain.Entities;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;
using Shouldly;

namespace RateMovie.UnitTests.Users.Update
{
    public class UpdateUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestUpdateUserJsonBuilder.Build();
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = async () => await useCase.Execute(request);

            await execute.ShouldNotThrowAsync();
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public async Task Should_Fail_If_Name_Is_Null(string name)
        {
            var request = new RequestUpdateUserJson(name);
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var execute = async () => await useCase.Execute(request);
            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.GetErrors().ShouldHaveSingleItem(ErrorMessagesResource.NAME_EMPTY);
        }

        private UpdateUserUseCase CreateUseCase(User user)
        {
            var unitOfWork = UnitOfWorkBuilder.Build();
            var userWriteOnly = UserWriteOnlyRepositoryBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);

            return new UpdateUserUseCase(unitOfWork, userWriteOnly, loggedUser);
        }
    }
}
