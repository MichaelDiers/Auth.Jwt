namespace Auth.Jwt.Web.Contracts.Models
{
    using System.Security.Claims;

    /// <summary>
    ///     Defines the roles that are used with the <see cref="Microsoft.AspNetCore.Authorization.AuthorizeAttribute" />
    /// </summary>
    public static class Roles
    {
        /// <summary>
        ///     Can change the data of <see cref="AuthUser" />.
        /// </summary>
        public const string AuthAdmin = nameof(Roles.AuthAdmin);

        /// <summary>
        ///     Combination of all auth roles.
        /// </summary>
        public const string AuthAll = Roles.AuthUser + "," + Roles.AuthAdmin + "," + Roles.AuthSuperUser;

        /// <summary>
        ///     Can change the data of all users.
        /// </summary>
        public const string AuthSuperUser = nameof(Roles.AuthSuperUser);

        /// <summary>
        ///     Cannot change the data of other users.
        /// </summary>
        public const string AuthUser = nameof(Roles.AuthUser);

        /// <summary>
        ///     Check if the user has any auth role claim.
        /// </summary>
        /// <param name="user">The user to be checked.</param>
        /// <returns>True if a role exists and false otherwise.</returns>
        public static bool HasAnyAuthRole(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.AuthAdmin) ||
                   user.IsInRole(Roles.AuthSuperUser) ||
                   user.IsInRole(Roles.AuthUser);
        }
    }
}
