namespace Auth.Jwt.Web.Contracts.Models
{
    public interface IRsaKeys
    {
        /// <summary>
        ///     Gets the rsa private key.
        /// </summary>
        string PrivateKey { get; }

        /// <summary>
        ///     Gets the rsa public key.
        /// </summary>
        string PublicKey { get; }
    }
}
