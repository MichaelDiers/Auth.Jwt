namespace Auth.Jwt.Web.Services
{
    using Auth.Jwt.Web.Contracts.Services;
    using BCrypt.Net;

    /// <summary>
    ///     Service for hashing and verifying passwords.
    /// </summary>
    public class HashService : IHashService
    {
        /// <summary>
        ///     Hash a password.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>The password hash.</returns>
        public string Hash(string password)
        {
            return BCrypt.HashPassword(password);
        }

        /// <summary>
        ///     Verify if the given <paramref name="password" /> and <paramref name="hash" /> do match.
        /// </summary>
        /// <param name="password">The password as plain text.</param>
        /// <param name="hash">The matching hash of the <paramref name="password" />.</param>
        /// <returns>True if password and hash do match and false otherwise.</returns>
        public bool Verify(string password, string hash)
        {
            return BCrypt.Verify(
                password,
                hash);
        }
    }
}
