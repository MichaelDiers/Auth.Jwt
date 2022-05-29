namespace Auth.Jwt.Web.Services
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models;
    using Auth.Jwt.Web.Contracts.Models.Requests;
    using Auth.Jwt.Web.Contracts.Models.Response;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Filters;
    using Auth.Jwt.Web.Models.Database;
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
        ///     Service for generating json web tokens.
        /// </summary>
        private readonly IJwtService jwtService;

        /// <summary>
        ///     Initializes a new instance of the AuthenticationService class.
        /// </summary>
        /// <param name="databaseService">A service for accessing the user database.</param>
        /// <param name="hashService">Service for hashing and verifying passwords.</param>
        /// <param name="jwtService">Service for generating json web tokens.</param>
        public AuthenticationService(IDatabaseService databaseService, IHashService hashService, IJwtService jwtService)
        {
            this.databaseService = databaseService;
            this.hashService = hashService;
            this.jwtService = jwtService;
        }

        /// <summary>
        ///     Authenticates a user.
        /// </summary>
        /// <param name="request">The data needed for signing in a user.</param>
        /// <returns>A <see cref="Task{T}" /> whose result is a <see cref="ITokenResponse" />.</returns>
        public async Task<ITokenResponse> AuthenticateAsync(ISignInRequest request)
        {
            var user = await this.databaseService.GetAsync(request.UserName.NormalizeUserName());
            if (user == null ||
                !this.hashService.Verify(
                    request.Password,
                    user.Password))
            {
                return new TokenResponse();
            }

            var token = await this.jwtService.Create(user);
            return new TokenResponse(token);
        }

        /// <summary>
        ///     Sign up a new user.
        /// </summary>
        /// <param name="request">The data of the new user.</param>
        /// <returns>
        ///     A <see cref="Task{T}" /> whose result is a <see cref="ITokenResponse" />. The
        ///     <see cref="ITokenResponse.Token" /> is set if the user is created and null otherwise.
        /// </returns>
        public async Task<ITokenResponse> SignUp(ISignUpRequest request)
        {
            var user = await this.databaseService.GetAsync(request.UserName.NormalizeUserName());
            if (user != null)
            {
                return new TokenResponse();
            }

            var userName = request.UserName.NormalizeUserName();
            user = new UserEntity(
                userName,
                this.hashService.Hash(request.Password),
                new[]
                {
                    new ClaimEntity(
                        ClaimTypes.Role,
                        Roles.AuthUser),
                    new ClaimEntity(
                        ClaimTypes.Name,
                        request.UserName),
                    new ClaimEntity(
                        ClaimTypes.NameIdentifier,
                        userName),
                    new ClaimEntity(
                        EmailValidatedFilter.IsEmailValidatedClaimType,
                        false.ToString())
                },
                userName);
            await this.databaseService.SetAsync(user);
            var token = await this.jwtService.Create(user);
            return new TokenResponse(token);
        }

        /// <summary>
        ///     Validate the email of a user.
        /// </summary>
        /// <param name="request">The data of the request.</param>
        /// <returns>A <see cref="Task{TResult}" /> whose result is an <see cref="ITokenResponse" />.</returns>
        public async Task<ITokenResponse> ValidateEmail(IValidateEmailRequest request)
        {
            var user = await this.databaseService.GetAsync(request.UserName.NormalizeUserName());
            if (user == null)
            {
                return new TokenResponse();
            }

            if (!user.EmailValidationCode.Equals(
                    request.EmailValidationCode,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                return new TokenResponse();
            }

            user.SetEmailIsValidated();
            await this.databaseService.UpdateAsync(user);

            var token = await this.jwtService.Create(user);
            return new TokenResponse(token);
        }
    }
}
