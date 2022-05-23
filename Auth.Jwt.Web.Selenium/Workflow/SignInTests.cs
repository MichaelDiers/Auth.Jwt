namespace Auth.Jwt.Web.Selenium.Workflow
{
    using System;
    using Auth.Jwt.Web.Selenium.Pages.SignIn;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using Xunit;

    public class SignInTests
    {
        [Theory]
        [InlineData(nameof(ChromeDriver))]
        [InlineData(nameof(FirefoxDriver))]
        [InlineData(nameof(EdgeDriver))]
        public void SignIn(string browser)
        {
            var driver = SignInTests.CreateWebDriver(browser);
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000");

                SignInPage.Create(driver).SignIn("userName", "password");
                UserPage.Create(driver);
            }
            finally
            {
                driver.Quit();
            }
        }

        private static IWebDriver CreateWebDriver(string browser)
        {
            switch (browser)
            {
                case nameof(ChromeDriver):
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    return new ChromeDriver(chromeOptions);
                case nameof(FirefoxDriver):
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--headless");
                    return new FirefoxDriver(firefoxOptions);
                case nameof(EdgeDriver):
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--headless");
                    return new EdgeDriver(edgeOptions);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
