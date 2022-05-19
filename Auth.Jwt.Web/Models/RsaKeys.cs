namespace Auth.Jwt.Web.Models
{
    using System;
    using Auth.Jwt.Web.Contracts.Models;

    /// <summary>
    ///     Container for private and public rsa keys.
    /// </summary>
    public class RsaKeys : IRsaKeys
    {
        /// <summary>
        ///     Initializes a new instance of the RsaKeys class.
        /// </summary>
        public RsaKeys(string privateKey, string publicKey)
        {
            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(privateKey));
            }

            if (string.IsNullOrWhiteSpace(publicKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(publicKey));
            }

            this.PrivateKey = privateKey;
            this.PublicKey = publicKey;
        }

        /// <summary>
        ///     Gets the rsa private key.
        /// </summary>
        public string PrivateKey { get; }

        /// <summary>
        ///     Gets the rsa public key.
        /// </summary>
        public string PublicKey { get; }
    }
}
