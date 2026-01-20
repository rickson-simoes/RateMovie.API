using RateMovie.Application.UseCases.Users;
using RateMovie.Communication.Requests;
using Shouldly;
using Tests.CommonUtilities.Requests;

namespace Tests.RateMovieApp.Users.UnitTests.Validators
{
    public class PasswordValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validation = new PasswordValidator<RequestAddUserJson>();
            var request = RequestAddUserJsonBuilder.Build();

            var result = validation.IsValid(new FluentValidation.ValidationContext<RequestAddUserJson>(request), request.Password);

            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("aaaaaaa")]
        [InlineData("aaaaaaa!")]
        [InlineData("aaaaaaa!1")]
        [InlineData("AAAAAAAA")]
        [InlineData("AAAAAAA!")]
        [InlineData("AAAAAAA!1")]
        [InlineData("AAAAaaaa")]
        [InlineData("AAAAaaaa12")]
        [InlineData("AAAA12@")]
        [InlineData("aaaa12@")]
        public void Should_Fail_When_Password_Is_Invalid(string password)
        {
            var validation = new PasswordValidator<RequestAddUserJson>();
            var request = new RequestAddUserJson();

            var result = validation.IsValid(new FluentValidation.ValidationContext<RequestAddUserJson>(request), password);

            result.ShouldBeFalse();
        }
    }
}
