namespace Auth.Jwt.Web.Contracts.Models.Database
{
    /// <summary>
    ///     Defines a claim of a user entity.
    /// </summary>
    public interface IClaimEntity
    {
        /// <summary>
        ///     Gets the type of the claim.
        /// </summary>
        string ClaimType { get; }

        /// <summary>
        ///     Gets the value of the claim.
        /// </summary>
        string ClaimValue { get; }
    }
}
