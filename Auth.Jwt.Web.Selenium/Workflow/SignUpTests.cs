namespace Auth.Jwt.Web.Selenium.Workflow
{
    using Auth.Jwt.Web.Selenium.Pages;
    using OpenQA.Selenium;
    using Xunit;

    public class SignUpTests : TestBase
    {
        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void LinkFromSignUpToSignIn(string driverName)
        {
            var (_, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToSignUpIndexPage(driver).ClickSignInLink();
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignUp(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                false,
                false);

            StartPage.ToSignUpIndexPage(driver)
                .UserName(testData.UserName)
                .Password(testData.Password)
                .PasswordRepeat(testData.Password)
                .SubmitSuccess();
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignUpFailsPasswordsDoNotMatch(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                false,
                false);

            StartPage.ToSignUpIndexPage(driver)
                .UserName(testData.UserName)
                .Password(testData.Password)
                .PasswordRepeat($"{testData.Password}a")
                // ReSharper disable once StringLiteralTypo
                .SubmitFail(By.CssSelector("[data-valmsg-for=Password]"));
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignUpFailsPasswordTooShort(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                false,
                false);

            StartPage.ToSignUpIndexPage(driver)
                .UserName(testData.UserName)
                .Password("aaa")
                .PasswordRepeat("aaa")
                // ReSharper disable once StringLiteralTypo
                .SubmitFail(By.CssSelector("[data-valmsg-for=Password]"));
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignUpFailsUserNameExists(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToSignUpIndexPage(driver)
                .UserName(testData.UserName)
                .Password(testData.Password)
                .PasswordRepeat(testData.Password)
                .SubmitFail(By.CssSelector(".validation-summary-errors"));
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void SignUpFailsUserNameTooShort(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                false,
                false);

            StartPage.ToSignUpIndexPage(driver)
                .UserName("aaa")
                .Password(testData.Password)
                .PasswordRepeat(testData.Password)
                // ReSharper disable once StringLiteralTypo
                .SubmitFail(By.CssSelector("[data-valmsg-for=UserName]"));
        }
    }
}
