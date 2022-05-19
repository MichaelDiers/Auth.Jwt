namespace Auth.Jwt.Web.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Database;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Models.Database;

    /// <summary>
    ///     Defines operations on databases.
    /// </summary>
    public class DatabaseService : IDatabaseService
    {
        /// <summary>
        ///     The user database.
        /// </summary>
        private readonly Dictionary<string, IUserEntity> users;

        /// <summary>
        ///     Initializes a new instance of the DatabaseService class.
        /// </summary>
        /// <param name="hashService">A service for hashing passwords.</param>
        public DatabaseService(IHashService hashService)
        {
            this.users = new Dictionary<string, IUserEntity>
            {
                {
                    "USERNAME",
                    new UserEntity("USERNAME", hashService.Hash("password"), new[] {new ClaimEntity("foo", "bar")})
                }
            };
        }

        /// <summary>
        ///     Reads a user by the given <paramref name="userName" />.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <returns>A <see cref="Task{T}" /> whose result is an <see cref="IUserEntity" /> or null if the user does not exists.</returns>
        public async Task<IUserEntity?> GetAsync(string userName)
        {
            await Task.CompletedTask;
            return this.users.TryGetValue(userName, out var user) ? user : null;
        }
    }
}
