namespace Auth.Jwt.Web.Tests.Contracts.Models
{
    using System.Linq;
    using System.Security.Claims;
    using Auth.Jwt.Web.Contracts.Models;
    using Xunit;

    /// <summary>
    ///     Tests for <see cref="Roles" />.
    /// </summary>
    public class RolesTests
    {
        [Theory]
        [InlineData(Roles.AuthUser)]
        [InlineData(Roles.AuthAdmin)]
        [InlineData(Roles.AuthSuperUser)]
        [InlineData(Roles.AuthAll)]
        public void HasAnyAuthRole(string role)
        {
            var claims = role.Split(",").Select(claimValue => new Claim(ClaimTypes.Role, claimValue)).ToArray();
            var user = new ClaimsPrincipal(new[] {new ClaimsIdentity(claims)});
            Assert.True(user.HasAnyAuthRole());
        }

        [Fact]
        public void HasAnyAuthRoleReturnsFalse()
        {
            var user = new ClaimsPrincipal();
            Assert.False(user.HasAnyAuthRole());
        }
    }
}
