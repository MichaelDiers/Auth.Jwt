namespace Auth.Jwt.Web.Selenium.Workflow
{
    using System;
    using Auth.Jwt.Web.Selenium.Pages;
    using Xunit;

    public class SignUpTests : TestBase
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SignUpFail(TestData testData)
        {
            var driver = this.Init(testData);

            SignInPage.Create(driver)
                .ToSignUpIndexPage()
                .SignUp(
                    testData.UserName,
                    testData.Password,
                    testData.Password)
                .VerifyOnPage()
                .ValidationSummaryErrorsIsVisible();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SignUpSuccess(TestData testData)
        {
            var driver = this.Init(testData);

            var userName = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();

            SignInPage.Create(driver)
            .ToSignUpIndexPage()
            .SignUp(
                userName,
                password,
                password);

            // Todo: check page
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SwitchToSignIn(TestData testData)
        {
            var driver = this.Init(testData);

            SignInPage.Create(driver).ToSignUpIndexPage().ToSignInPage();
        }
    }
}
