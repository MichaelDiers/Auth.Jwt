namespace Auth.Jwt.Web.Selenium.Pages.SignIn
{
    using Auth.Jwt.Web.Controllers.Mvc;
    using OpenQA.Selenium;

    /// <summary>
    ///     Model of the user page.
    /// </summary>
    internal class UserPage : BasePage
    {
        /// <summary>
        ///     Initializes a new instance of the UserPage class.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        protected UserPage(IWebDriver driver)
            : base(driver, UserController.IndexViewAuit)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the UserPage class
        ///     and verifies that the current page is displayed.
        /// </summary>
        /// <param name="driver">The current web driver.</param>
        /// <returns>A new <see cref="UserPage" />.</returns>
        public static UserPage Create(IWebDriver driver)
        {
            return new UserPage(driver).VerifyOnPage();
        }

        /// <summary>
        ///     Verify that the current page is displayed.
        /// </summary>
        /// <returns>A self reference.</returns>
        public UserPage VerifyOnPage()
        {
            this.CheckOnPage();
            return this;
        }
    }
}
