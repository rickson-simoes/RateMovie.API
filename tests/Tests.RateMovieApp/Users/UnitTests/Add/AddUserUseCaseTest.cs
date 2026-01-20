using RateMovie.Application.UseCases.Users.Add;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;
using Shouldly;
using System.Net;
using Tests.CommonUtilities.Repositories.UnitOfWork;
using Tests.CommonUtilities.Repositories.Users;
using Tests.CommonUtilities.Requests;
using Tests.CommonUtilities.Security.PasswordHasher;
using Tests.CommonUtilities.Security.TokenGenerator;

namespace Tests.RateMovieApp.Users.UnitTests.Add
{
    public class AddUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var requestAddUser = RequestAddUserJsonBuilder.Build();
            var useCase = CreateUseCase();

            var testResponse = await useCase.Execute(requestAddUser);

            testResponse.ShouldNotBeNull();
            testResponse.Email.ShouldBe(requestAddUser.Email);
            testResponse.Name.ShouldBe(requestAddUser.Name);
            testResponse.Token.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task Should_Fail_When_Email_Already_Exists()
        {
            var requestAddUser = RequestAddUserJsonBuilder.Build();
            var useCase = CreateUseCase(requestAddUser.Email);

            var execute = async () => await useCase.Execute(requestAddUser);

            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().Count().ShouldBe(1);
            testResponse.GetErrors().ShouldContain(ErrorMessagesResource.EMAIL_ALREADY_EXISTS);            
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public async Task Should_Fail_When_Name_Is_Null_Or_Empty(string name)
        {
            var requestAddUser = RequestAddUserJsonBuilder.Build();
            requestAddUser.Name = name;
            var useCase = CreateUseCase();

            var execute = async () => await useCase.Execute(requestAddUser);

            var testResponse = await execute.ShouldThrowAsync<ValidationHandlerException>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().Count().ShouldBe(1);
            testResponse.GetErrors().ShouldContain(ErrorMessagesResource.NAME_EMPTY);
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
