namespace Auth.Jwt.Web.Controllers.Mvc
{
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Contracts.Settings;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Models.Requests;
    using Auth.Jwt.Web.ViewModels.SignIn;
    using Auth.Jwt.Web.ViewModels.SignUp;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Options;

    public class AuthenticateController : BaseController
    {
        /// <summary>
        ///     The automated user interface tests id of the sign in view.
        /// </summary>
        public const string SignInViewAuit = "auit760D2E86_9B97_4E57_B26F_7C2BCBD8130E";

        /// <summary>
        ///     The automated user interface tests id of the sign up view.
        /// </summary>
        public const string SignUpViewAuit = "auit-734A785B-CEA0-4484-8037-4CC76FA87761";

        /// <summary>
        ///     Service for authenticating users.
        /// </summary>
        private readonly IAuthenticationService authenticationService;

        /// <summary>
        ///     Settings for creating and verifying json web tokens.
        /// </summary>
        private readonly IOptions<JwtSettings> jwtSettings;

        private readonly IStringLocalizer<AuthenticateController> localizer;

        /// <summary>
        ///     Initializes a new instance of the AuthenticateController class.
        /// </summary>
        /// <param name="authenticationService">Service for authenticating users.</param>
        /// <param name="jwtSettings">Settings for creating and verifying json web tokens.</param>
        /// <param name="localizer">A text localizer.</param>
        public AuthenticateController(
            IAuthenticationService authenticationService,
            IOptions<JwtSettings> jwtSettings,
            IStringLocalizer<AuthenticateController> localizer
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
            this.SetAuit(AuthenticateController.SignInViewAuit);
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
            this.SetAuit(AuthenticateController.SignInViewAuit);
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

        /// <summary>
        ///     Request the sign up view.
        /// </summary>
        /// <returns>An <see cref="IActionResult" />.</returns>
        [HttpGet]
        public IActionResult SignUp()
        {
            this.SetAuit(AuthenticateController.SignUpViewAuit);
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(SignUpViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var tokenResponse =
                await this.authenticationService.SignUp(new SignUpRequest(viewModel.UserName, viewModel.Password));
            if (string.IsNullOrWhiteSpace(tokenResponse.Token))
            {
                this.ModelState.AddModelError(string.Empty, this.localizer["SignUpUserExists"]);
                return this.View(viewModel);
            }

            this.Response.Cookies.Append(this.jwtSettings.Value.CookieName, tokenResponse.Token);
            return this.RedirectToAction(nameof(this.ValidateEmail));
        }

        [HttpGet]
        public IActionResult ValidateEmail()
        {
            return this.View();
        }
    }
}
