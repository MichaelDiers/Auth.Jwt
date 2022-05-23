namespace Auth.Jwt.Web.Contracts.Models
{
    using System.Security.Claims;

    public static class Roles
    {
        public const string AuthAdmin = nameof(Roles.AuthAdmin);

        public const string AuthAll = Roles.AuthUser + "," + Roles.AuthAdmin + "," + Roles.AuthSuperUser;

        public const string AuthSuperUser = nameof(Roles.AuthSuperUser);

        public const string AuthUser = nameof(Roles.AuthUser);

        public static bool HasAnyAuthRole(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.AuthAdmin) ||
                   user.IsInRole(Roles.AuthSuperUser) ||
                   user.IsInRole(Roles.AuthUser);
        }
    }
}
