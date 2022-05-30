namespace Auth.Jwt.Web.Selenium.Pages
{
    using Auth.Jwt.Web.Controllers.Mvc;
    using OpenQA.Selenium;

    /// <summary>
    ///     Model of the user page.
    /// </summary>
    internal class UserIndexPage : BasePage
    {
        /// <summary>
        ///     Initializes a new instance of the UserIndexPage class.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        protected UserIndexPage(IWebDriver driver)
            : base(
                driver,
                UserController.UserIndexViewAuit)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the UserIndexPage class
        ///     and verifies that the current page is displayed.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        /// <returns>A new <see cref="UserIndexPage" />.</returns>
        public static UserIndexPage Create(IWebDriver driver)
        {
            return new UserIndexPage(driver).VerifyOnPage();
        }

        public SignInPage Logout()
        {
            this.Click(By.Id("logout"));
            return this.Create(SignInPage.Create);
        }

        /// <summary>
        ///     Verify that the current page is displayed.
        /// </summary>
        /// <returns>A self reference.</returns>
        public UserIndexPage VerifyOnPage()
        {
            this.CheckOnPage();
            return this;
        }
    }
}
