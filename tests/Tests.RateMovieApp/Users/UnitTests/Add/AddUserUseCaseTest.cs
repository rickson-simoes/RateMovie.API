using RateMovie.Application.UseCases.Users.Add;
using Tests.CommonUtilities.Repositories.UnitOfWork;
using Tests.CommonUtilities.Repositories.Users;
using Tests.CommonUtilities.Requests;
using Tests.CommonUtilities.Security.PasswordHasher;
using Tests.CommonUtilities.Security.TokenGenerator;
using Shouldly;

namespace Tests.RateMovieApp.Users.UnitTests.Add
{
    public class AddUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var requestAddUser = RequestAddUserJsonBuilder.Builder();
            var useCase = CreateUseCase();

            var testResponse = await useCase.Execute(requestAddUser);

            testResponse.ShouldNotBeNull();
            testResponse.Email.ShouldBe(requestAddUser.Email);
            testResponse.Name.ShouldBe(requestAddUser.Name);
            testResponse.Token.ShouldNotBeNullOrEmpty();
        }

        private AddUserUseCase CreateUseCase(string? email = null)
        {
            var unitOfWork = UnitOfWorkBuilder.Build();
            var userWriteOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();
            var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder();
            var passwordHasher = new PasswordHasherBuilder().HashPassword().Build();
            var tokenGenerator = TokenGeneratorBuilder.Build();

            if (string.IsNullOrWhiteSpace(email) is false)
            {
                userReadOnlyRepository.EmailExists(email);
            }

            return new AddUserUseCase(
                unitOfWork, 
                userWriteOnlyRepository, 
                userReadOnlyRepository.Build(),
                passwordHasher,
                tokenGenerator);
        }
    }
}
