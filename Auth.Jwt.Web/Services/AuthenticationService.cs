namespace Auth.Jwt.Web.Services
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;

    public class AuthenticationService : IAuthenticationService
    {
        public async Task<string> AuthenticateAsync(string userName, string password)
        {
            await Task.CompletedTask;
            return "";
        }
    }
}
