namespace Auth.Jwt.Web.Contracts.Models.Requests
{
    /// <summary>
    ///     Specifies the request for validating emails.
    /// </summary>
    public interface IValidateEmailRequest
    {
        /// <summary>
        ///     Get the code for validating emails.
        /// </summary>
        string EmailValidationCode { get; }

        /// <summary>
        ///     Gets the name of the user.
        /// </summary>
        string UserName { get; }
    }
}
