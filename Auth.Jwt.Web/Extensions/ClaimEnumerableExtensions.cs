namespace Auth.Jwt.Web.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    /// <summary>
    ///     Extensions for <see cref="IEnumerable{T}" /> of <see cref="Claim" />
    /// </summary>
    public static class ClaimEnumerableExtensions
    {
        /// <summary>
        ///     Gets the claim value for the given <paramref name="claimType" />.
        /// </summary>
        /// <param name="claims">A enumerable of claims.</param>
        /// <param name="claimType">The type of the claim.</param>
        /// <returns>The value of the claim type or throws an exception.</returns>
        public static string Get(this IEnumerable<Claim> claims, string claimType)
        {
            return claims.First(claim => claim.Type == claimType).Value;
        }
    }
}
