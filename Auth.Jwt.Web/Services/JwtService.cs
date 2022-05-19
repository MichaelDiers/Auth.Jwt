namespace Auth.Jwt.Web.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Models.Database;
    using Auth.Jwt.Web.Contracts.Services;
    using Microsoft.IdentityModel.Tokens;

    public class JwtService : IJwtService
    {
        /// <summary>
        ///     Service for accessing the google cloud secret manager.
        /// </summary>
        private readonly ISecretService secretService;

        /// <summary>
        ///     Initializes a new instance of the JwtService class.
        /// </summary>
        /// <param name="secretService">Service for accessing the google cloud secret manager.</param>
        public JwtService(ISecretService secretService)
        {
            this.secretService = secretService;
        }

        /// <summary>
        ///     Create new json web token.
        /// </summary>
        /// <param name="user">The user data for that the token is created.</param>
        /// <returns>A new token.</returns>
        public async Task<string> Create(IUserEntity user)
        {
            var keys = await this.secretService.GetAsync();

            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(keys.PrivateKey), out _);

            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory {CacheSignatureProviders = false}
            };

            var claims = user.Claims.Select(claim => new Claim(claim.ClaimType, claim.ClaimValue)).ToArray();

            var jwtSecurityToken = new JwtSecurityToken(
                "Issuer",
                "Audience",
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
