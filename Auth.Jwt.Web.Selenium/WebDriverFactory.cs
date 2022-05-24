namespace Auth.Jwt.Web.Selenium
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;

    /// <summary>
    ///     A factory for creating web drivers.
    /// </summary>
    internal class WebDriverFactory
    {
        /// <summary>
        ///     Create a <see cref="WebDriver" /> by name.
        /// </summary>
        /// <param name="name">The name of the <see cref="WebDriver" />.</param>
        /// <returns>An <see cref="IWebDriver" />.</returns>
        public static IWebDriver Create(string name)
        {
            switch (name)
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
