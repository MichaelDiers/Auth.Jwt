namespace Auth.Jwt.Web.Contracts.Services
{
    public interface IHashService
    {
        /// <summary>
        ///     Hash a password.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>The password hash.</returns>
        string Hash(string password);

        /// <summary>
        ///     Verify if the given <paramref name="password" /> and <paramref name="hash" /> do match.
        /// </summary>
        /// <param name="password">The password as plain text.</param>
        /// <param name="hash">The matching hash of the <paramref name="password" />.</param>
        /// <returns>True if password and hash do match and false otherwise.</returns>
        bool Verify(string password, string hash);
    }
}
