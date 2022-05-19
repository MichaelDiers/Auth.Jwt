namespace Auth.Jwt.Web.Contracts.Settings
{
    /// <summary>
    ///     Specifies the settings for handling json web tokens.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        ///     Gets or sets the audience of the token.
        /// </summary>
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the name of the jwt cookie.
        /// </summary>
        public string CookieName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the expiration time in minutes.
        /// </summary>
        public int Expires { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the issuer of the token.
        /// </summary>
        public string Issuer { get; set; } = string.Empty;
    }
}
