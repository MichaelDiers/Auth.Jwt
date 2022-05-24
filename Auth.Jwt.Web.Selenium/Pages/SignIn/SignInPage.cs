namespace Auth.Jwt.Web.Selenium.Pages.SignIn
{
    using Auth.Jwt.Web.Controllers.Mvc;
    using OpenQA.Selenium;

    /// <summary>
    ///     Model of the sign in page.
    /// </summary>
    internal class SignInPage : BasePage
    {
        /// <summary>
        ///     Initializes a new instance of the SignInPage class.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        protected SignInPage(IWebDriver driver)
            : base(driver, AuthenticateController.SignInViewAuit)
        {
        }

        /// <summary>
        ///     Create a new instance of the <see cref="SignInPage" />
        ///     and verify the page is displayed.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        /// <returns>A new <see cref="SignInPage" />.</returns>
        public static SignInPage Create(IWebDriver driver)
        {
            return new SignInPage(driver).VerifyOnPage();
        }

        /// <summary>
        ///     Set the password of the form.
        /// </summary>
        /// <param name="password">The text that is set to the password input.</param>
        /// <returns>A self reference.</returns>
        public SignInPage Password(string password)
        {
            this.SendKeys(By.Id("Password"), password);
            return this;
        }

        /// <summary>
        ///     Sign in with user name and password.
        /// </summary>
        /// <param name="userName">The text that is set as user name.</param>
        /// <param name="password">The text that is set as password.</param>
        /// <returns>A self reference.</returns>
        public SignInPage SignIn(string userName, string password)
        {
            return this.UserName(userName).Password(password).Submit();
        }

        /// <summary>
        ///     Submit the form data.
        /// </summary>
        /// <returns>A self reference.</returns>
        public SignInPage Submit()
        {
            this.Submit(By.CssSelector("input[type=submit]"));
            return this;
        }

        /// <summary>
        ///     Use a link to the <see cref="SignUpIndexPage" />.
        /// </summary>
        /// <returns>A new <see cref="SignUpIndexPage" />.</returns>
        public SignUpIndexPage ToSignUpIndexPage()
        {
            this.Click(By.CssSelector("main form ~ a"));
            return this.Create(SignUpIndexPage.Create);
        }

        /// <summary>
        ///     Set the text of the user name input.
        /// </summary>
        /// <param name="userName">The text of the user name.</param>
        /// <returns>A self reference.</returns>
        public SignInPage UserName(string userName)
        {
            this.SendKeys(By.Id("UserName"), userName);
            return this;
        }

        /// <summary>
        ///     Verify that the current page is displayed.
        /// </summary>
        /// <returns>A self reference.</returns>
        public SignInPage VerifyOnPage()
        {
            this.CheckOnPage();
            return this;
        }
    }
}
