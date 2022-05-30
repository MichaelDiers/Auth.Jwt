namespace Auth.Jwt.Web.Selenium
{
    using System;
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Selenium.Pages;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;

    public class TestBase : IDisposable
    {
        protected IWebDriver? WebDriver { get; set; }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.WebDriver?.Quit();
        }

        protected (TestData testData, IWebDriver driver) Init(string driverName, bool userExists, bool emailIsValidated)
        {
            var testData = new TestData(
                driverName,
                $"user{Guid.NewGuid()}",
                Guid.NewGuid().ToString(),
                "http://localhost:5000");

            var driver = this.Init(testData);
            if (userExists)
            {
                var page = StartPage.ToSignInPage(driver)
                    .ClickSignUpLink()
                    .UserName(testData.UserName)
                    .Password(testData.Password)
                    .PasswordRepeat(testData.Password)
                    .SubmitSuccess();
                if (emailIsValidated)
                {
                    page.ValidationCode(testData.UserName.NormalizeUserName()).SubmitSuccess().Logout();
                }
                else
                {
                    page.Logout();
                }
            }

            return (testData, driver);
        }

        protected IWebDriver Init(TestData testData)
        {
            switch (testData.Driver)
            {
                case nameof(ChromeDriver):
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    this.WebDriver = new ChromeDriver(chromeOptions);
                    break;
                case nameof(EdgeDriver):
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--headless");
                    this.WebDriver = new EdgeDriver(edgeOptions);
                    break;
                case nameof(FirefoxDriver):
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--headless");
                    this.WebDriver = new FirefoxDriver(firefoxOptions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(testData.Driver),
                        testData.Driver,
                        "Unhandled value.");
            }

            this.WebDriver.Navigate().GoToUrl(testData.Url);
            return this.WebDriver;
        }
    }
}
