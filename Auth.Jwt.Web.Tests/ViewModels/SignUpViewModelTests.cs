namespace Auth.Jwt.Web.Tests.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Auth.Jwt.Web.ViewModels.SignUp;
    using Xunit;

    /// <summary>
    ///     Tests for <see cref="SignUpViewModel" />.
    /// </summary>
    public class SignUpViewModelTests
    {
        public void Ctor()
        {
            var viewModel = new SignUpViewModel();
            Assert.Equal(
                string.Empty,
                viewModel.UserName);
            Assert.Equal(
                string.Empty,
                viewModel.PasswordRepeat);
            Assert.Equal(
                string.Empty,
                viewModel.Password);
        }

        [Theory]
        [InlineData(
            "",
            "password",
            "passwordRepeat")]
        [InlineData(
            "userName",
            "",
            "passwordRepeat")]
        [InlineData(
            "userName",
            "password",
            "")]
        public void CtorFails(string userName, string password, string passwordRepeat)
        {
            Assert.Throws<ArgumentException>(
                () => new SignUpViewModel(
                    userName,
                    password,
                    passwordRepeat));
        }

        [Theory]
        [InlineData(
            "userName",
            "password",
            "passwordRepeat")]
        public void CtorSucceeds(string userName, string password, string passwordRepeat)
        {
            var viewModel = new SignUpViewModel(
                userName,
                password,
                passwordRepeat);
            Assert.Equal(
                userName,
                viewModel.UserName);
            Assert.Equal(
                password,
                viewModel.Password);
            Assert.Equal(
                passwordRepeat,
                viewModel.PasswordRepeat);
        }

        [Fact]
        public void MemberIsNotSet()
        {
            var viewModel = new SignUpViewModel();
            SignUpViewModelTests.Validate(
                viewModel,
                (nameof(viewModel.UserName), nameof(RequiredAttribute)),
                (nameof(viewModel.Password), nameof(RequiredAttribute)),
                (nameof(viewModel.PasswordRepeat), nameof(RequiredAttribute)));
        }

        [Fact]
        public void PasswordMismatch()
        {
            var viewModel = new SignUpViewModel(
                new string(
                    'a',
                    10),
                new string(
                    'a',
                    10),
                new string(
                    'b',
                    10));
            SignUpViewModelTests.Validate(
                viewModel,
                (nameof(viewModel.Password), nameof(CompareAttribute)),
                (nameof(viewModel.PasswordRepeat), nameof(CompareAttribute)));
        }

        [Theory]
        [InlineData(
            4,
            4)]
        [InlineData(
            100,
            100)]
        public void ValidationSucceeds(int userNameLength, int passwordLength)
        {
            var viewModel = new SignUpViewModel(
                new string(
                    'a',
                    userNameLength),
                new string(
                    'b',
                    passwordLength),
                new string(
                    'b',
                    passwordLength));
            SignUpViewModelTests.Validate(viewModel);
        }

        [Fact]
        public void ValueTooLong()
        {
            var viewModel = new SignUpViewModel(
                new string(
                    'a',
                    101),
                new string(
                    'a',
                    101),
                new string(
                    'a',
                    101));
            SignUpViewModelTests.Validate(
                viewModel,
                (nameof(viewModel.UserName), nameof(StringLengthAttribute)),
                (nameof(viewModel.Password), nameof(StringLengthAttribute)),
                (nameof(viewModel.PasswordRepeat), nameof(StringLengthAttribute)));
        }

        [Fact]
        public void ValueTooShort()
        {
            var viewModel = new SignUpViewModel(
                "123",
                "123",
                "123");
            SignUpViewModelTests.Validate(
                viewModel,
                (nameof(viewModel.UserName), nameof(StringLengthAttribute)),
                (nameof(viewModel.Password), nameof(StringLengthAttribute)),
                (nameof(viewModel.PasswordRepeat), nameof(StringLengthAttribute)));
        }

        private static void Validate<T>(T viewModel, params (string member, string message)[] errors)
        {
            var context = new ValidationContext(
                viewModel,
                null,
                null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(
                viewModel,
                context,
                results,
                true);
            Assert.Equal(
                !errors.Any(),
                valid);
            Assert.Equal(
                errors.Length,
                results.Count);
            if (errors.Any())
            {
                Assert.Contains(
                    errors,
                    error => results.Any(
                        result => result.ErrorMessage == error.message &&
                                  (error.message == nameof(CompareAttribute) ||
                                   result.MemberNames.Contains(error.member))));
            }
        }
    }
}
