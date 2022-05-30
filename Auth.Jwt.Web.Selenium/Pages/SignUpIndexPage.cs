namespace Auth.Jwt.Web.Selenium.Pages
{
    using Auth.Jwt.Web.Controllers.Mvc;
    using Auth.Jwt.Web.ViewModels.SignUp;
    using OpenQA.Selenium;

    internal class SignUpIndexPage : BasePage
    {
        /// <summary>
        ///     Initializes a new instance of the SignUpIndexPage class.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        protected SignUpIndexPage(IWebDriver driver)
            : base(
                driver,
                AuthenticateController.SignUpViewAuit)
        {
        }

        /// <summary>
        ///     Use the link to the sign in page.
        /// </summary>
        /// <returns>A new <see cref="SignInPage" />.</returns>
        public SignInPage ClickSignInLink()
        {
            this.Click(By.CssSelector("main form ~ a"));
            return this.Create(SignInPage.Create);
        }

        /// <summary>
        ///     Create a new instance of the <see cref="SignUpIndexPage" />
        ///     and verify the page is displayed.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        /// <returns>A new <see cref="SignUpIndexPage" />.</returns>
        public static SignUpIndexPage Create(IWebDriver driver)
        {
            return new SignUpIndexPage(driver).VerifyOnPage();
        }

        /// <summary>
        ///     Set the password of the form.
        /// </summary>
        /// <param name="password">The text that is set to the password input.</param>
        /// <returns>A self reference.</returns>
        public SignUpIndexPage Password(string password)
        {
            this.SendKeys(
                By.Id(nameof(SignUpViewModel.Password)),
                password);
            return this;
        }

        /// <summary>
        ///     Set the repeated password of the form.
        /// </summary>
        /// <param name="password">The text that is set to the password input.</param>
        /// <returns>A self reference.</returns>
        public SignUpIndexPage PasswordRepeat(string password)
        {
            this.SendKeys(
                By.Id(nameof(SignUpViewModel.PasswordRepeat)),
                password);
            return this;
        }

        /// <summary>
        ///     Sign in with user name and password.
        /// </summary>
        /// <param name="userName">The text that is set as user name.</param>
        /// <param name="password">The text that is set as password.</param>
        /// <param name="passwordRepeat">The text that is set as repeated password.</param>
        /// <returns>A self reference.</returns>
        public SignUpIndexPage SignUp(string userName, string password, string passwordRepeat)
        {
            return this.UserName(userName).Password(password).PasswordRepeat(passwordRepeat).Submit();
        }

        /// <summary>
        ///     Submit the form data.
        /// </summary>
        /// <returns>A self reference.</returns>
        public SignUpIndexPage Submit()
        {
            this.Submit(By.CssSelector("input[type=submit]"));
            return this;
        }

        public SignUpIndexPage SubmitFail(By errorMessage)
        {
            this.Submit(By.CssSelector("input[type=submit]"));
            this.IsDisplayed(errorMessage);
            return this;
        }

        public ValidateEmailPage SubmitSuccess()
        {
            this.Submit(By.CssSelector("input[type=submit]"));
            return this.Create(ValidateEmailPage.Create);
        }

        /// <summary>
        ///     Set the text of the user name input.
        /// </summary>
        /// <param name="userName">The text of the user name.</param>
        /// <returns>A self reference.</returns>
        public SignUpIndexPage UserName(string userName)
        {
            this.SendKeys(
                By.Id(nameof(SignUpViewModel.UserName)),
                userName);
            return this;
        }

        /// <summary>
        ///     Check if validation summary is displayed.
        /// </summary>
        /// <returns></returns>
        public SignUpIndexPage ValidationSummaryErrorsIsVisible()
        {
            this.IsDisplayed(By.CssSelector(".validation-summary-errors"));
            return this;
        }

        /// <summary>
        ///     Verify that the current page is displayed.
        /// </summary>
        /// <returns>A self reference.</returns>
        public SignUpIndexPage VerifyOnPage()
        {
            this.CheckOnPage();
            return this;
        }
    }
}
