namespace Auth.Jwt.Web.Controllers.Mvc
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Contracts.Settings;
    using Auth.Jwt.Web.Models.Requests;
    using Auth.Jwt.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Options;

    [Authorize]
    public class AuthenticateController : Controller
    {
        public const string Name = "Authenticate";
        private readonly IAuthenticationService authenticationService;
        private readonly IOptions<JwtSettings> jwtSettings;
        private readonly IStringLocalizer<AuthenticateController> localizer;

        public AuthenticateController(
            IStringLocalizer<AuthenticateController> localizer,
            IAuthenticationService authenticationService,
            IOptions<JwtSettings> jwtSettings
        )
        {
            this.localizer = localizer;
            this.authenticationService = authenticationService;
            this.jwtSettings = jwtSettings;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (!this.TempData.TryGetValue(nameof(SignInViewModel), out var viewModel))
            {
                viewModel = new SignInViewModel();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromForm] SignInViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var response =
                await this.authenticationService.AuthenticateAsync(
                    new SignInRequest(viewModel.UserName, viewModel.Password));
            if (!string.IsNullOrWhiteSpace(response.Token))
            {
                this.Response.Cookies.Append(this.jwtSettings.Value.CookieName, response.Token);
                return this.RedirectToAction(nameof(DashboardController.Index), DashboardController.Name);
            }

            this.ModelState.AddModelError(string.Empty, this.localizer["InvalidUserNamePasswordError"]);
            return this.View(viewModel);
        }
    }
}
