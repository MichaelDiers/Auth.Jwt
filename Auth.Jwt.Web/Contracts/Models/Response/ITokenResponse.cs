namespace Auth.Jwt.Web.Contracts.Models.Response
{
    /// <summary>
    ///     Describes a response with a json web token.
    /// </summary>
    public interface ITokenResponse
    {
        /// <summary>
        ///     Gets the json web token. The value is null if an authentication request failed.
        /// </summary>
        string? Token { get; }
    }
}
