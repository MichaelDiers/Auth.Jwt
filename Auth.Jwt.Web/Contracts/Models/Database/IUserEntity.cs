namespace Auth.Jwt.Web.Contracts.Models.Database
{
    using System.Collections.Generic;

    /// <summary>
    ///     Defines the data of the user database entity.
    /// </summary>
    public interface IUserEntity
    {
        /// <summary>
        ///     Gets the claims of a user.
        /// </summary>
        IEnumerable<IClaimEntity> Claims { get; }

        /// <summary>
        ///     Gets the code for email validation.
        /// </summary>
        string EmailValidationCode { get; }

        /// <summary>
        ///     Gets the password of a user.
        /// </summary>
        string Password { get; }

        /// <summary>
        ///     Gets the name of the user.
        /// </summary>
        string UserName { get; }

        /// <summary>
        ///     Set the claim that the email is validated.
        /// </summary>
        void SetEmailIsValidated();
    }
}
