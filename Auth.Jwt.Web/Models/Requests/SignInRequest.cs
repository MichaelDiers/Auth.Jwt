namespace Auth.Jwt.Web.Models.Requests
{
    using System;
    using System.Text.Json.Serialization;
    using Auth.Jwt.Web.Contracts.Models.Requests;

    /// <summary>
    ///     Specifies the data for signing in a user.
    /// </summary>
    public class SignInRequest : ISignInRequest
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="SignInRequest" /> class.
        ///     Default constructor for deserialize operations only.
        /// </summary>
        public SignInRequest()
        {
            this.Password = string.Empty;
            this.UserName = string.Empty;
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="SignInRequest" /> class.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        public SignInRequest(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(password));
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(userName));
            }

            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        ///     Gets the password of the user.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        ///     Gets the name of the user.
        /// </summary>
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
    }
}
