namespace Auth.Jwt.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models;
    using Auth.Jwt.Web.Contracts.Models.Database;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Filters;
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
                    "USERNAME", new UserEntity(
                        "USERNAME",
                        hashService.Hash("password"),
                        new[]
                        {
                            new ClaimEntity(
                                ClaimTypes.Role,
                                Roles.AuthUser),
                            new ClaimEntity(
                                ClaimTypes.Name,
                                "UserName"),
                            new ClaimEntity(
                                ClaimTypes.NameIdentifier,
                                "USERNAME"),
                            new ClaimEntity(
                                EmailValidatedFilter.IsEmailValidatedClaimType,
                                true.ToString())
                        },
                        "USERNAME")
                },
                {
                    "ADMIN", new UserEntity(
                        "ADMIN",
                        hashService.Hash("password"),
                        new[]
                        {
                            new ClaimEntity(
                                ClaimTypes.Role,
                                Roles.AuthUser),
                            new ClaimEntity(
                                ClaimTypes.Role,
                                Roles.AuthAdmin),
                            new ClaimEntity(
                                ClaimTypes.Name,
                                "Admin"),
                            new ClaimEntity(
                                ClaimTypes.NameIdentifier,
                                "ADMIN"),
                            new ClaimEntity(
                                EmailValidatedFilter.IsEmailValidatedClaimType,
                                true.ToString())
                        },
                        "ADMIN")
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
            return this.users.TryGetValue(
                userName,
                out var user)
                ? user
                : null;
        }

        /// <summary>
        ///     Insert a new <see cref="UserEntity" /> into the users collection.
        /// </summary>
        /// <param name="entity">The entity that is added.</param>
        /// <returns>A <see cref="Task" /> that indicates termination.</returns>
        public async Task SetAsync(IUserEntity entity)
        {
            var user = await this.GetAsync(entity.UserName);
            if (user != null)
            {
                throw new Exception();
            }

            this.users.Add(
                entity.UserName,
                entity);
        }

        /// <summary>
        ///     Update a user entity by replacing it.
        /// </summary>
        /// <param name="entity">The new entity data.</param>
        /// <returns>A <see cref="Task" /> that indicates completion.</returns>
        public async Task UpdateAsync(IUserEntity entity)
        {
            var user = await this.GetAsync(entity.UserName);
            if (user == null)
            {
                throw new Exception();
            }

            this.users[entity.UserName] = entity;
        }
    }
}
