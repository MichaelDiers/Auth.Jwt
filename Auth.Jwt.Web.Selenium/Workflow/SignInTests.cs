namespace Auth.Jwt.Web.Selenium.Workflow
{
    using Auth.Jwt.Web.Selenium.Pages.SignIn;
    using Auth.Jwt.Web.Selenium.Pages.User;
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
            SeleniumRunner.Run(SignInTests.SignInTest, browser, "http://localhost:5000");
        }

        [Theory]
        [InlineData(nameof(ChromeDriver))]
        [InlineData(nameof(FirefoxDriver))]
        [InlineData(nameof(EdgeDriver))]
        public void SwitchToSignUp(string browser)
        {
            SeleniumRunner.Run(SignInTests.SwitchToSignUpTest, browser, "http://localhost:5000");
        }

        private static void SignInTest(IWebDriver driver)
        {
            SignInPage.Create(driver).SignIn("userName", "password");
            UserPage.Create(driver);
        }

        private static void SwitchToSignUpTest(IWebDriver driver)
        {
            SignInPage.Create(driver).ToSignUpIndexPage();
        }
    }
}
