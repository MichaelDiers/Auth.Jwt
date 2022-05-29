namespace Auth.Jwt.Web.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Auth.Jwt.Web.Contracts.Models.Database;
    using Auth.Jwt.Web.Filters;

    /// <summary>
    ///     Defines the data of the user database entity.
    /// </summary>
    public class UserEntity : IUserEntity
    {
        /// <summary>
        ///     Initializes a new instance of the UserEntity class.
        ///     Default constructor is used for deserialization.
        /// </summary>
        public UserEntity()
        {
            this.EmailValidationCode = string.Empty;
            this.Password = string.Empty;
            this.UserName = string.Empty;
            this.Claims = Enumerable.Empty<IClaimEntity>();
        }

        /// <summary>
        ///     Initializes a new instance of the UserEntity class.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="claims">The claims of the user.</param>
        /// <param name="emailValidationCode">The code for email validation.</param>
        public UserEntity(
            string userName,
            string password,
            IEnumerable<IClaimEntity> claims,
            string emailValidationCode
        )
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(password));
            }

            if (string.IsNullOrWhiteSpace(emailValidationCode))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(emailValidationCode));
            }

            this.UserName = userName;
            this.Password = password;
            this.Claims = claims ?? throw new ArgumentNullException(nameof(claims));
            this.EmailValidationCode = emailValidationCode;
        }

        /// <summary>
        ///     Gets or sets the claims of a user.
        /// </summary>
        public IEnumerable<IClaimEntity> Claims { get; set; }

        /// <summary>
        ///     Gets or sets the code for email validation.
        /// </summary>
        public string EmailValidationCode { get; set; }

        /// <summary>
        ///     Gets or sets the password of a user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Set the claim that the email is validated.
        /// </summary>
        public void SetEmailIsValidated()
        {
            this.Claims = this.Claims.Where(claim => claim.ClaimType != EmailValidatedFilter.IsEmailValidatedClaimType)
                .Append(
                    new ClaimEntity(
                        EmailValidatedFilter.IsEmailValidatedClaimType,
                        true.ToString()))
                .ToArray();
        }
    }
}
