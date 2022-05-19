namespace Auth.Jwt.Web.Contracts.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models;

    /// <summary>
    ///     Service for accessing the google cloud secret manager.
    /// </summary>
    public interface ISecretService
    {
        /// <summary>
        ///     Gets the rsa private and public keys.
        /// </summary>
        /// <returns>A <see cref="Task{T}" /> whose result is an <see cref="IRsaKeys" /> container.</returns>
        Task<IRsaKeys> GetAsync();
    }
}
