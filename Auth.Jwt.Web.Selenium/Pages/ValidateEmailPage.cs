namespace Auth.Jwt.Web.Selenium.Pages
{
    using Auth.Jwt.Web.Controllers.Mvc;
    using Auth.Jwt.Web.ViewModels.Authenticate;
    using OpenQA.Selenium;

    internal class ValidateEmailPage : BasePage
    {
        private readonly By submit = By.CssSelector("[type=submit]");

        /// <summary>
        ///     Initializes a new instance of the BasePage class.
        /// </summary>
        /// <param name="driver">The current selenium web driver.</param>
        protected ValidateEmailPage(IWebDriver driver)
            : base(
                driver,
                AuthenticateController.ValidateEmailAuit)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the ValidateEmailPage class
        ///     and verifies that the current page is displayed.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        /// <returns>A new <see cref="ValidateEmailPage" />.</returns>
        public static ValidateEmailPage Create(IWebDriver driver)
        {
            return new ValidateEmailPage(driver).VerifyOnPage();
        }

        /// <summary>
        ///     Logout the current user.
        /// </summary>
        /// <returns>A self reference.</returns>
        public SignInPage Logout()
        {
            this.Click(By.Id("logout"));
            return this.Create(SignInPage.Create);
        }

        public ValidateEmailPage SubmitFail()
        {
            this.Submit(this.submit);
            return this;
        }

        public UserIndexPage SubmitSuccess()
        {
            this.Submit(this.submit);
            return this.Create(UserIndexPage.Create);
        }

        /// <summary>
        ///     Sets the code for email validation.
        /// </summary>
        /// <param name="code">The validation code.</param>
        /// <returns>A self reference.</returns>
        public ValidateEmailPage ValidationCode(string code)
        {
            this.SendKeys(
                By.Id(nameof(ValidateEmailViewModel.ValidationCode)),
                code);
            return this;
        }

        /// <summary>
        ///     Verify that the current page is displayed.
        /// </summary>
        /// <returns>A self reference.</returns>
        public ValidateEmailPage VerifyOnPage()
        {
            this.CheckOnPage();
            return this;
        }
    }
}
