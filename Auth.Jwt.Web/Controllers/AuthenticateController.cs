namespace Auth.Jwt.Web.Controllers
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;

    public class AuthenticateController : Controller
    {
        public const string Name = "Authenticate";
        private readonly IAuthenticationService authenticationService;
        private readonly IStringLocalizer<AuthenticateController> localizer;

        public AuthenticateController(
            IStringLocalizer<AuthenticateController> localizer,
            IAuthenticationService authenticationService
        )
        {
            this.localizer = localizer;
            this.authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            if (!this.TempData.TryGetValue(nameof(SignInViewModel), out var viewModel))
            {
                viewModel = new SignInViewModel();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] SignInViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var token = await this.authenticationService.AuthenticateAsync(viewModel.UserName, viewModel.Password);
            if (!string.IsNullOrWhiteSpace(token))
            {
                return this.RedirectToAction(nameof(DashboardController.Index), DashboardController.Name);
            }

            this.ModelState.AddModelError(string.Empty, this.localizer["InvalidUserNamePasswordError"]);
            return this.View(viewModel);
        }
    }
}
