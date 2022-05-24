namespace Auth.Jwt.Web.Selenium.Workflow
{
    using System;
    using Auth.Jwt.Web.Selenium.Pages.SignIn;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using Xunit;

    public class SignUpTests
    {
        [Theory]
        [InlineData(nameof(ChromeDriver))]
        [InlineData(nameof(FirefoxDriver))]
        [InlineData(nameof(EdgeDriver))]
        public void SignUp(string browser)
        {
            SeleniumRunner.Run(SignUpTests.SignUpTest, browser, "http://localhost:5000");
        }

        [Theory]
        [InlineData(nameof(ChromeDriver))]
        [InlineData(nameof(FirefoxDriver))]
        [InlineData(nameof(EdgeDriver))]
        public void SwitchToSignIn(string browser)
        {
            SeleniumRunner.Run(SignUpTests.SwitchToSignInTest, browser, "http://localhost:5000");
        }

        private static void SignUpTest(IWebDriver driver)
        {
            var userName = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            SignInPage.Create(driver).ToSignUpIndexPage().SignUp(userName, password);
        }

        private static void SwitchToSignInTest(IWebDriver driver)
        {
            SignInPage.Create(driver).ToSignUpIndexPage().ToSignInPage();
        }
    }
}
