namespace Auth.Jwt.Web.Selenium.Workflow
{
    using System;
    using Auth.Jwt.Web.Selenium.Pages;
    using OpenQA.Selenium;
    using Xunit;

    public class SignInTests : TestBase
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void LogoutNotVisibleOnSignIn(TestData testData)
        {
            var driver = this.Init(testData);

            SignInPage.Create(driver);
            var thrown = false;
            try
            {
                driver.FindElement(By.Id("logout"));
            }
            catch (NoSuchElementException)
            {
                thrown = true;
            }

            Assert.True(thrown);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SignInFail(TestData testData)
        {
            var driver = this.Init(testData);

            SignInPage.Create(driver)
                .SignIn(
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString())
                .VerifyOnPage();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SignInSuccess(TestData testData)
        {
            var driver = this.Init(testData);

            SignInPage.Create(driver)
            .SignIn(
                testData.UserName,
                testData.Password);
            UserIndexPage.Create(driver);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SwitchToSignUp(TestData testData)
        {
            var driver = this.Init(testData);

            SignInPage.Create(driver).ToSignUpIndexPage();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void VerifyStartPage(TestData testData)
        {
            var driver = this.Init(testData);
            SignInPage.Create(driver);
        }
    }
}
