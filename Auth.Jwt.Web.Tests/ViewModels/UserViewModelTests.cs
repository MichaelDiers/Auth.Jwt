namespace Auth.Jwt.Web.Tests.ViewModels
{
    using System;
    using Auth.Jwt.Web.ViewModels.User;
    using Xunit;

    public class UserViewModelTests
    {
        [Fact]
        public void Ctor()
        {
            var user = new UserViewModel();
            Assert.Equal(string.Empty, user.UserName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void CtorFails(string userName)
        {
            Assert.Throws<ArgumentException>(() => new UserViewModel(userName));
        }

        [Theory]
        [InlineData("userName")]
        public void CtorSucceeds(string userName)
        {
            var user = new UserViewModel(userName);
            Assert.Equal(userName, user.UserName);
        }
    }
}
