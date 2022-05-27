namespace Auth.Jwt.Web.Controllers.Mvc
{
    using System;
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Contracts.Settings;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Models.Requests;
    using Auth.Jwt.Web.ViewModels.SignIn;
    using Auth.Jwt.Web.ViewModels.SignUp;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Options;

    public class AuthenticateController : BaseController
    {
        /// <summary>
        ///     The automated user interface tests id of the sign in view.
        /// </summary>
        public const string SignInViewAuit = nameof(AuthenticateController.SignInViewAuit);

        /// <summary>
        ///     The automated user interface tests id of the sign up view.
        /// </summary>
        public const string SignUpViewAuit = nameof(AuthenticateController.SignUpViewAuit);

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

        [HttpGet]
        public IActionResult Logout()
        {
            this.AddCookie(string.Empty);
            return this.RedirectToAction(nameof(AuthenticateController.SignIn));
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

            var tokenResponse = await this.authenticationService.AuthenticateAsync(
                new SignInRequest(
                    viewModel.UserName,
                    viewModel.Password));
            if (string.IsNullOrWhiteSpace(tokenResponse.Token))
            {
                this.ModelState.AddModelError(
                    string.Empty,
                    this.localizer["UnknownUserPasswordCombination"]);
                return this.View(viewModel);
            }

            this.AddCookie(tokenResponse.Token);
            return this.RedirectToAction(
                nameof(UserController.Index),
                nameof(UserController).ControllerName());
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
                this.SetAuit(AuthenticateController.SignUpViewAuit);
                return this.View(viewModel);
            }

            var tokenResponse = await this.authenticationService.SignUp(
                new SignUpRequest(
                    viewModel.UserName,
                    viewModel.Password));
            if (string.IsNullOrWhiteSpace(tokenResponse.Token))
            {
                this.ModelState.AddModelError(
                    string.Empty,
                    this.localizer["SignUpUserExists"]);
                this.SetAuit(AuthenticateController.SignUpViewAuit);
                return this.View(viewModel);
            }

            this.AddCookie(tokenResponse.Token);
            return this.RedirectToAction(nameof(this.ValidateEmail));
        }

        [HttpGet]
        public IActionResult ValidateEmail()
        {
            return this.View();
        }

        private void AddCookie(string value)
        {
            var options = new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.Strict,
                HttpOnly = true
            };

            if (string.IsNullOrWhiteSpace(value))
            {
                options.Expires = DateTimeOffset.UtcNow.AddDays(-2);
            }

            this.Response.Cookies.Append(
                this.jwtSettings.Value.CookieName,
                value,
                options);
        }
    }
}
