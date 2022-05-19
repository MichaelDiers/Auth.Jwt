namespace Auth.Jwt.Web.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Requests;
    using Auth.Jwt.Web.Contracts.Models.Response;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Models.Responses;

    /// <summary>
    ///     Authentication operations for users.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        ///     Authenticates a user.
        /// </summary>
        /// <param name="request">The data needed for signing in a user.</param>
        /// <returns>A <see cref="Task{T}" /> whose result is a <see cref="ITokenResponse" />.</returns>
        public async Task<ITokenResponse> AuthenticateAsync(ISignInRequest request)
        {
            await Task.CompletedTask;
            return new TokenResponse();
        }
    }
}
