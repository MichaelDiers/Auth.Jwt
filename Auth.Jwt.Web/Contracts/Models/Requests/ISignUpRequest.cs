namespace Auth.Jwt.Web.Contracts.Models.Requests
{
    /// <summary>
    ///     Specifies the data for signing up a user.
    /// </summary>
    public interface ISignUpRequest
    {
        /// <summary>
        ///     Gets the password of the user.
        /// </summary>
        string Password { get; }

        /// <summary>
        ///     Gets the name of the user.
        /// </summary>
        string UserName { get; }
    }
}
