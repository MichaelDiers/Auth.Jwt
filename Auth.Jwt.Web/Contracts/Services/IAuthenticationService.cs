namespace Auth.Jwt.Web.Contracts.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Requests;
    using Auth.Jwt.Web.Contracts.Models.Response;

    /// <summary>
    ///     Authentication operations for users.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        ///     Authenticates a user.
        /// </summary>
        /// <param name="request">The data needed for signing in a user.</param>
        /// <returns>A <see cref="Task{T}" /> whose result is a <see cref="ITokenResponse" />.</returns>
        Task<ITokenResponse> AuthenticateAsync(ISignInRequest request);

        /// <summary>
        ///     Sign up a new user.
        /// </summary>
        /// <param name="request">The data of the new user.</param>
        /// <returns>
        ///     A <see cref="Task{T}" /> whose result is a <see cref="ITokenResponse" />. The
        ///     <see cref="ITokenResponse.Token" /> is set if the user is created and null otherwise.
        /// </returns>
        Task<ITokenResponse> SignUp(ISignUpRequest request);

        /// <summary>
        ///     Validate the email of a user.
        /// </summary>
        /// <param name="request">The data of the request.</param>
        /// <returns>A <see cref="Task{TResult}" /> whose result is an <see cref="ITokenResponse" />.</returns>
        Task<ITokenResponse> ValidateEmail(IValidateEmailRequest request);
    }
}
