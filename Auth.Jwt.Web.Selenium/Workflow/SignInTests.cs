namespace Auth.Jwt.Web.Selenium.Workflow
{
    using Auth.Jwt.Web.Selenium.Pages;
    using OpenQA.Selenium;
    using Xunit;

    public class SignInTests : TestBase
    {
        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void LinkFromSignInToSignUp(string driverName)
        {
            var (_, driver) = this.Init(
                driverName,
                false,
                false);

            StartPage.ToSignInPage(driver).ClickSignUpLink();
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignInFailsUsingInvalidPassword(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToSignInPage(driver)
                .UserName(testData.UserName)
                .Password($"{testData.Password}a")
                .SubmitFails(By.CssSelector(".validation-summary-errors"));
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignInFailsUsingUnknownUser(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                false,
                false);

            StartPage.ToSignInPage(driver)
                .UserName(testData.UserName)
                .Password(testData.Password)
                .SubmitFails(By.CssSelector(".validation-summary-errors"));
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignInUsingValidatedEmail(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                true);

            StartPage.ToSignInPage(driver)
                .UserName(testData.UserName)
                .Password(testData.Password)
                .SubmitSuccess(UserIndexPage.Create);
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignInWithUnvalidatedEmail(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToSignInPage(driver)
                .UserName(testData.UserName)
                .Password(testData.Password)
                .SubmitSuccess(ValidateEmailPage.Create);
        }
    }
}
