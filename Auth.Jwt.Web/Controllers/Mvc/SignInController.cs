namespace Auth.Jwt.Web.Controllers.Mvc
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Contracts.Settings;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Models.Requests;
    using Auth.Jwt.Web.ViewModels.SignIn;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Options;

    /// <summary>
    ///     Authenticate a user by name and password.
    /// </summary>
    public class SignInController : Controller
    {
        /// <summary>
        ///     Service for authentication.
        /// </summary>
        private readonly IAuthenticationService authenticationService;

        /// <summary>
        ///     The settings for creating json web tokens and its cookies.
        /// </summary>
        private readonly IOptions<JwtSettings> jwtSettings;

        /// <summary>
        ///     Localize text that is display in the view.
        /// </summary>
        private readonly IStringLocalizer<SignInController> localizer;

        /// <summary>
        ///     Initializes a new instance of the SignInController class.
        /// </summary>
        /// <param name="authenticationService">Service for authenticating users.</param>
        /// <param name="jwtSettings">The settings for creating json web tokens and its cookies.</param>
        /// <param name="localizer">Localize text for the view.</param>
        public SignInController(
            IAuthenticationService authenticationService,
            IOptions<JwtSettings> jwtSettings,
            IStringLocalizer<SignInController> localizer
        )
        {
            this.authenticationService = authenticationService;
            this.jwtSettings = jwtSettings;
            this.localizer = localizer;
        }

        /// <summary>
        ///     Request the sign in a view.
        /// </summary>
        /// <returns>An <see cref="IActionResult" />.</returns>
        [HttpGet]
        public IActionResult SignIn()
        {
            return this.View();
        }

        /// <summary>
        ///     Authenticate a user by name and password.
        /// </summary>
        /// <param name="viewModel">The required data for authenticating a user.</param>
        /// <returns>The sign in view if the authentication fails and redirects to the <see cref="UserController" /> otherwise.</returns>
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
            if (string.IsNullOrWhiteSpace(tokenResponse.Token))
            {
                this.ModelState.AddModelError(string.Empty, this.localizer["UnknownUserPasswordCombination"]);
                return this.View(viewModel);
            }

            this.HttpContext.Response.Cookies.Append(this.jwtSettings.Value.CookieName, tokenResponse.Token);
            return this.RedirectToAction(nameof(UserController.Index), nameof(UserController).ControllerName());
        }
    }
}
