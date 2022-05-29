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

        /// <summary>
        ///     Insert a new <see cref="IUserEntity" /> into the users collection.
        /// </summary>
        /// <param name="entity">The entity that is added.</param>
        /// <returns>A <see cref="Task" /> that indicates termination.</returns>
        Task SetAsync(IUserEntity entity);

        /// <summary>
        ///     Update a user entity by replacing it.
        /// </summary>
        /// <param name="entity">The new entity data.</param>
        /// <returns>A <see cref="Task" /> that indicates completion.</returns>
        Task UpdateAsync(IUserEntity entity);
    }
}
