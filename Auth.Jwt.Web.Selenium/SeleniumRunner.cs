namespace Auth.Jwt.Web.Selenium
{
    using System;
    using OpenQA.Selenium;

    internal class SeleniumRunner
    {
        public static void Run(Action<IWebDriver> test, string browser, string url)
        {
            var driver = WebDriverFactory.Create(browser);
            try
            {
                driver.Navigate().GoToUrl(url);
                test(driver);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
