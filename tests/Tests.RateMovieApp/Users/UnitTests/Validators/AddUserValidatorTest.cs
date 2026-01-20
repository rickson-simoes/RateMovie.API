using FluentValidation.Results;
using RateMovie.Application.UseCases.Users.Add;
using RateMovie.Communication.Requests;
using RateMovie.Exception;
using Shouldly;
using Tests.CommonUtilities.Requests;

namespace Tests.RateMovieApp.Users.UnitTests.Validators
{
    public class AddUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            var requestBuilder = RequestAddUserJsonBuilder.Build();
            var validator = Validation(requestBuilder);

            validator.IsValid.ShouldBe(true);
            validator.Errors.ShouldBeEmpty();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        public void Should_Fail_When_Name_Null_Or_Empty(string name)
        {
            var requestBuilder = RequestAddUserJsonBuilder.Build();
            requestBuilder.Name = name;

            var validator = Validation(requestBuilder);

            validator.IsValid.ShouldBe(false);
            validator.Errors.Count.ShouldBe(1);
            validator.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ErrorMessagesResource.NAME_EMPTY);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        public void Should_Fail_When_Email_Is_Null_Or_Empty(string email)
        {
            var requestBuilder = RequestAddUserJsonBuilder.Build();
            requestBuilder.Email = email;

            var validator = Validation(requestBuilder);

            validator.Errors.Count.ShouldBe(1);
            validator.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ErrorMessagesResource.EMAIL_EMPTY);
            validator.IsValid.ShouldBe(false);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("test.com")]
        public void Should_Fail_When_Email_Is_Invalid(string email)
        {
            var requestBuilder = RequestAddUserJsonBuilder.Build();
            requestBuilder.Email = email;

            var validator = Validation(requestBuilder);

            validator.Errors.Count.ShouldBe(1);
            validator.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ErrorMessagesResource.EMAIL_INVALID);
            validator.IsValid.ShouldBe(false);
        }

        [Fact]
        public void Should_Fail_When_Password_Is_Invalid()
        {
            var requestBuilder = RequestAddUserJsonBuilder.Build();
            requestBuilder.Password = string.Empty;

            var validator = Validation(requestBuilder);

            validator.Errors.Count.ShouldBe(1);
            validator.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ErrorMessagesResource.PASSWORD_INVALID);
            validator.IsValid.ShouldBe(false);
        }

        public ValidationResult Validation(RequestAddUserJson request)
        {
            return new AddUserValidator().Validate(request);
        }
    }
}
