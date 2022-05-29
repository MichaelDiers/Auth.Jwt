namespace Auth.Jwt.Web.Models.Requests
{
    using System;
    using Auth.Jwt.Web.Contracts.Models.Requests;

    /// <summary>
    ///     Specifies the request for validating emails.
    /// </summary>
    public class ValidateEmailRequest : IValidateEmailRequest

    {
        /// <summary>
        ///     Initializes a new instance of the ValidateEmailRequest class.
        /// </summary>
        public ValidateEmailRequest(string userName, string emailValidationCode)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(emailValidationCode))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(emailValidationCode));
            }

            this.UserName = userName;
            this.EmailValidationCode = emailValidationCode;
        }

        /// <summary>
        ///     Gets or sets the code for validating emails.
        /// </summary>
        public string EmailValidationCode { get; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; }
    }
}
