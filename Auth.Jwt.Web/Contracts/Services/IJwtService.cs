namespace Auth.Jwt.Web.Contracts.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Database;
    using Microsoft.AspNetCore.Authentication.JwtBearer;

    /// <summary>
    ///     Service for creating json web tokens.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        ///     Create new json web token.
        /// </summary>
        /// <param name="user">The user data for that the token is created.</param>
        /// <returns>A new token.</returns>
        Task<string> Create(IUserEntity user);

        /// <summary>
        ///     Set the options of the given <see cref="JwtBearerOptions" />.
        /// </summary>
        /// <param name="options">The options that are set.</param>
        void SetOptions(JwtBearerOptions options);
    }
}
