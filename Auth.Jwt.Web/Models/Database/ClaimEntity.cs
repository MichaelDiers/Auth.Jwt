namespace Auth.Jwt.Web.Models.Database
{
    using System;
    using Auth.Jwt.Web.Contracts.Models.Database;

    /// <summary>
    ///     Defines a claim of a user entity.
    /// </summary>
    public class ClaimEntity : IClaimEntity
    {
        /// <summary>
        ///     Initializes a new instance of the ClaimEntity class.
        /// </summary>
        public ClaimEntity()
        {
            this.ClaimType = string.Empty;
            this.ClaimValue = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the ClaimEntity class.
        ///     Default constructor is needed for deserialization.
        /// </summary>
        /// <param name="claimType">The type of the claim.</param>
        /// <param name="claimValue">The value of the claim.</param>
        public ClaimEntity(string claimType, string claimValue)
        {
            if (string.IsNullOrWhiteSpace(claimType))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(claimType));
            }

            if (string.IsNullOrWhiteSpace(claimValue))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(claimValue));
            }

            this.ClaimType = claimType;
            this.ClaimValue = claimValue;
        }

        /// <summary>
        ///     Gets or sets the type of the claim.
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the claim.
        /// </summary>
        public string ClaimValue { get; set; }
    }
}
