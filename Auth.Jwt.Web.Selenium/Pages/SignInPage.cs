namespace Auth.Jwt.Web.Selenium.Pages
{
    using System;
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
            : base(
                driver,
                AuthenticateController.SignInViewAuit)
        {
        }

        /// <summary>
        ///     Use a link to the <see cref="SignUpIndexPage" />.
        /// </summary>
        /// <returns>A new <see cref="SignUpIndexPage" />.</returns>
        public SignUpIndexPage ClickSignUpLink()
        {
            this.Click(By.CssSelector("main form ~ a"));
            return this.Create(SignUpIndexPage.Create);
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
            this.SendKeys(
                By.Id("Password"),
                password);
            return this;
        }

        /// <summary>
        ///     Submit the form data.
        /// </summary>
        /// <returns>A self reference.</returns>
        public SignInPage SubmitFails(By errorMessage)
        {
            this.Submit(By.CssSelector("input[type=submit]"));
            this.IsDisplayed(errorMessage);
            return this;
        }

        /// <summary>
        ///     Submit the form data.
        /// </summary>
        /// <returns>The destination page.</returns>
        public T SubmitSuccess<T>(Func<IWebDriver, T> create)
        {
            this.Submit(By.CssSelector("input[type=submit]"));
            return this.Create(create);
        }

        /// <summary>
        ///     Set the text of the user name input.
        /// </summary>
        /// <param name="userName">The text of the user name.</param>
        /// <returns>A self reference.</returns>
        public SignInPage UserName(string userName)
        {
            this.SendKeys(
                By.Id("UserName"),
                userName);
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
