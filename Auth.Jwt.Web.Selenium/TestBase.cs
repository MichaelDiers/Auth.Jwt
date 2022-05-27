namespace Auth.Jwt.Web.Selenium
{
    using System;
    using OpenQA.Selenium;

    public class TestBase : IDisposable
    {
        protected IWebDriver? WebDriver { get; set; }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.WebDriver?.Quit();
        }

        protected IWebDriver Init(TestData testData)
        {
            this.WebDriver = testData.Driver;
            this.WebDriver.Navigate().GoToUrl(testData.Url);
            return this.WebDriver;
        }
    }
}
