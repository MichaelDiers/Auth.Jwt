namespace Auth.Jwt.Web.Contracts.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Database;

    /// <summary>
    ///     Defines operations on databases.
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        ///     Reads a user by the given <paramref name="userName" />.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <returns>A <see cref="Task{T}" /> whose result is an <see cref="IUserEntity" /> or null if the user does not exists.</returns>
        Task<IUserEntity?> GetAsync(string userName);
    }
}
