namespace Auth.Jwt.Web.Contracts.Services
{
    using System.Threading.Tasks;

    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(string userName, string password);
    }
}
