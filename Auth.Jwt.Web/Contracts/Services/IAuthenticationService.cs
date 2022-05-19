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
    }
}
