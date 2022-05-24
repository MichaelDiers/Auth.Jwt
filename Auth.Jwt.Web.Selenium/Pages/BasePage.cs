namespace Auth.Jwt.Web.Selenium.Pages
{
    using System;
    using Auth.Jwt.Web.Controllers.Mvc;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Xunit;

    /// <summary>
    ///     Base page for selenium page models.
    /// </summary>
    internal class BasePage
    {
        /// <summary>
        ///     The id of the page.
        /// </summary>
        private readonly string auit;

        /// <summary>
        ///     The current selenium driver.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        ///     Initializes a new instance of the BasePage class.
        /// </summary>
        /// <param name="driver">The current selenium web driver.</param>
        /// <param name="auit">The id of the page.</param>
        protected BasePage(IWebDriver driver, string auit)
        {
            this.driver = driver;
            this.auit = auit;
        }

        /// <summary>
        ///     Check if the current page is displayed.
        /// </summary>
        protected void CheckOnPage()
        {
            var auitElement = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(
                webDriver => webDriver.FindElement(By.CssSelector($"[auit={this.auit}]")));
            Assert.Equal(this.auit, auitElement.GetAttribute(BaseController.Auit));
        }

        /// <summary>
        ///     Click a web element.
        /// </summary>
        /// <param name="by">The web element is identified by this selector.</param>
        protected void Click(By by)
        {
            this.driver.FindElement(by).Click();
        }

        /// <summary>
        ///     Create a new page.
        /// </summary>
        /// <typeparam name="T">The type of the page.</typeparam>
        /// <param name="create">A factory method for creating the page.</param>
        /// <returns></returns>
        protected T Create<T>(Func<IWebDriver, T> create)
        {
            return create(this.driver);
        }

        /// <summary>
        ///     Send keys to the specified element.
        /// </summary>
        /// <param name="by">The web element is identified by this selector.</param>
        /// <param name="keys">The keys that will be sent.</param>
        protected void SendKeys(By by, string keys)
        {
            this.driver.FindElement(by).SendKeys(keys);
        }

        /// <summary>
        ///     Submit a web element.
        /// </summary>
        /// <param name="by">The web element is identified by this selector.</param>
        protected void Submit(By by)
        {
            this.driver.FindElement(by).Submit();
        }
    }
}
