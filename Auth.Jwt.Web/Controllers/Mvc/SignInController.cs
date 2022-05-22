namespace Auth.Jwt.Web.Controllers.Mvc
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Contracts.Settings;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Models.Requests;
    using Auth.Jwt.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    public class SignInController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IOptions<JwtSettings> jwtSettings;

        public SignInController(IAuthenticationService authenticationService, IOptions<JwtSettings> jwtSettings)
        {
            this.authenticationService = authenticationService;
            this.jwtSettings = jwtSettings;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync(SignInViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var tokenResponse =
                await this.authenticationService.AuthenticateAsync(
                    new SignInRequest(viewModel.UserName, viewModel.Password));
            if (string.IsNullOrWhiteSpace(tokenResponse?.Token))
            {
                this.ModelState.AddModelError(string.Empty, "UnknownUserPasswordCombination");
                return this.View(viewModel);
            }

            this.HttpContext.Response.Cookies.Append(this.jwtSettings.Value.CookieName, tokenResponse.Token);
            return this.RedirectToAction(nameof(UserController.Index), nameof(UserController).ControllerName());
        }
    }
}
