using RateMovie.Application.UseCases.Login;
using RateMovie.CommonUtilities.Entities;
using RateMovie.CommonUtilities.Requests;
using RateMovie.CommonUtilities.Security.TokenGenerator;
using RateMovie.Domain.Entities;
using RateMovie.Exception;
using RateMovie.Exception.RateMovieExceptions;
using RateMovie.CommonUtilities.Repositories.Users;
using RateMovie.CommonUtilities.Security.PasswordHasher;
using Shouldly;
using System.Net;

namespace RateMovie.UnitTests.Login
{
    public class LoginUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var request = RequestLoginJsonBuilder.Build(user.Email);
            var createUseCase = CreateUseCase(user, request.Password);

            var testResponse = await createUseCase.Execute(request);

            testResponse.ShouldNotBeNull();
            testResponse.Email.ShouldBe(user.Email);
            testResponse.Name.ShouldBe(user.Name);
            testResponse.Token.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task Should_Fail_When_User_Is_Null()
        {

            var request = RequestLoginJsonBuilder.Build();
            var createUseCase = CreateUseCase();

            var execute = async () => await createUseCase.Execute(request);
            var testResponse = await execute.ShouldThrowAsync<GenericBadRequestError>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().Count().ShouldBe(1);
            testResponse.GetErrors().ShouldContain(ErrorMessagesResource.EMAIL_OR_PASSWORD_INVALID);
        }

        [Fact]
        public async Task Should_Fail_When_Password_Is_False()
        {
            var user = UserBuilder.Build();
            var request = RequestLoginJsonBuilder.Build(user.Email);
            var createUseCase = CreateUseCase(user);

            var execute = async () => await createUseCase.Execute(request);
            var testResponse = await execute.ShouldThrowAsync<GenericBadRequestError>();

            testResponse.ErrorStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            testResponse.GetErrors().Count().ShouldBe(1);
            testResponse.GetErrors().ShouldContain(ErrorMessagesResource.EMAIL_OR_PASSWORD_INVALID);
        }

        private LoginUseCase CreateUseCase(
            User? user = null, 
            string? requestPassword = null)
        {
            var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder();
            var passwordHasher = new PasswordHasherBuilder();
            var tokenGenerator = TokenGeneratorBuilder.Build();

            if (requestPassword is not null)
            {
                passwordHasher.VerifyPassword(requestPassword);
            }

            if (user is not null)
            {
                userReadOnlyRepository.GetByEmail(user);
            }

            return new LoginUseCase(userReadOnlyRepository.Build(), passwordHasher.Build(), tokenGenerator);
        }
    }
}
