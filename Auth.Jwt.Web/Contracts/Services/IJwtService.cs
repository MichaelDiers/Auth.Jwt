namespace Auth.Jwt.Web.Contracts.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Database;

    public interface IJwtService
    {
        /// <summary>
        ///     Create new json web token.
        /// </summary>
        /// <param name="user">The user data for that the token is created.</param>
        /// <returns>A new token.</returns>
        Task<string> Create(IUserEntity user);
    }
}
