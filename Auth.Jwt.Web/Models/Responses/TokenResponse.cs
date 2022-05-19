namespace Auth.Jwt.Web.Models.Responses
{
    using Auth.Jwt.Web.Contracts.Models.Response;

    /// <summary>
    ///     Describes a response with a json web token.
    /// </summary>
    public class TokenResponse : ITokenResponse
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="TokenResponse" /> class.
        /// </summary>
        public TokenResponse()
            : this(string.Empty)
        {
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="TokenResponse" /> class.
        /// </summary>
        /// <param name="token">A json web token.</param>
        public TokenResponse(string token)
        {
            this.Token = token;
        }

        /// <summary>
        ///     Gets the json web token. The value is <see cref="string.Empty" /> if an authentication request failed.
        /// </summary>
        public string Token { get; }
    }
}
