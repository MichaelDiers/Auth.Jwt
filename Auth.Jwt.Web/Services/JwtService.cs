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
    using Auth.Jwt.Web.Contracts.Settings;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    ///     Service for creating json web tokens.
    /// </summary>
    public class JwtService : IJwtService
    {
        /// <summary>
        ///     Service for accessing the google cloud secret manager.
        /// </summary>
        private readonly ISecretService secretService;

        private readonly IOptions<JwtSettings> settings;

        /// <summary>
        ///     Initializes a new instance of the JwtService class.
        /// </summary>
        /// <param name="secretService">Service for accessing the google cloud secret manager.</param>
        /// <param name="settings">The settings for handling jwt.</param>
        public JwtService(ISecretService secretService, IOptions<JwtSettings> settings)
        {
            this.secretService = secretService;
            this.settings = settings;
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
                this.settings.Value.Issuer,
                this.settings.Value.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(this.settings.Value.Expires),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        /// <summary>
        ///     Set the options of the given <see cref="JwtBearerOptions" />.
        /// </summary>
        /// <param name="options">The options that are set.</param>
        public void SetOptions(JwtBearerOptions options)
        {
            var keys = this.secretService.GetAsync().Result;
            var rsa = RSA.Create();
            rsa.ImportRSAPublicKey(Convert.FromBase64String(keys.PublicKey), out _);

            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = this.settings.Value.Issuer,
                ValidAudience = this.settings.Value.Audience,
                IssuerSigningKey = new RsaSecurityKey(rsa),
                CryptoProviderFactory = new CryptoProviderFactory {CacheSignatureProviders = false}
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies[this.settings.Value.CookieName];
                    return Task.CompletedTask;
                }
            };
        }
    }
}
