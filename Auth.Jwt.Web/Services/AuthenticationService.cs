namespace Auth.Jwt.Web.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Requests;
    using Auth.Jwt.Web.Contracts.Models.Response;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Models.Responses;

    /// <summary>
    ///     Authentication operations for users.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        ///     Access the user database.
        /// </summary>
        private readonly IDatabaseService databaseService;

        /// <summary>
        ///     Service for hashing and verifying passwords.
        /// </summary>
        private readonly IHashService hashService;

        /// <summary>
        ///     Initializes a new instance of the AuthenticationService class.
        /// </summary>
        /// <param name="databaseService">A service for accessing the user database.</param>
        /// <param name="hashService">Service for hashing and verifying passwords.</param>
        public AuthenticationService(IDatabaseService databaseService, IHashService hashService)
        {
            this.databaseService = databaseService;
            this.hashService = hashService;
        }

        /// <summary>
        ///     Authenticates a user.
        /// </summary>
        /// <param name="request">The data needed for signing in a user.</param>
        /// <returns>A <see cref="Task{T}" /> whose result is a <see cref="ITokenResponse" />.</returns>
        public async Task<ITokenResponse> AuthenticateAsync(ISignInRequest request)
        {
            var user = await this.databaseService.GetAsync(request.UserName.NormalizeUserName());
            if (user == null || !this.hashService.Verify(request.Password, user.Password))
            {
                return new TokenResponse();
            }

            return new TokenResponse("token");
        }
    }
}
