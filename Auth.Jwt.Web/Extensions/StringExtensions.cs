namespace Auth.Jwt.Web.Extensions
{
    /// <summary>
    ///     Extensions for <see cref="string" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Normalizes a user name for database operations.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <returns>The normalized user name.</returns>
        public static string NormalizeUserName(this string userName)
        {
            return userName.ToUpperInvariant();
        }
    }
}
