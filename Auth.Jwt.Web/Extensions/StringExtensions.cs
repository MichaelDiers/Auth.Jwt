namespace Auth.Jwt.Web.Extensions
{
    /// <summary>
    ///     Extensions for <see cref="string" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Remove the controller suffix from a controller name.
        /// </summary>
        /// <param name="controller">The of the controller.</param>
        /// <returns>The name of the controller without its suffix.</returns>
        public static string ControllerName(this string controller)
        {
            return controller[..^10];
        }

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
