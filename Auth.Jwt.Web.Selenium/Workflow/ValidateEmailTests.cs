namespace Auth.Jwt.Web.Selenium.Workflow
{
    using Auth.Jwt.Web.Extensions;
    using Auth.Jwt.Web.Selenium.Pages;
    using Xunit;

    public class ValidateEmailTests : TestBase
    {
        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void Logout(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToValidateEmailPage(
                    driver,
                    testData)
                .Logout();
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void ValidateEmail(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToValidateEmailPage(
                    driver,
                    testData)
                .ValidationCode(testData.UserName.NormalizeUserName())
                .SubmitSuccess();
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void ValidateEmailFailsUsingEmptyCode(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToValidateEmailPage(
                    driver,
                    testData)
                .SubmitFail();
        }

        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void ValidateEmailFailsUsingInvalidCode(string driverName)
        {
            var (testData, driver) = this.Init(
                driverName,
                true,
                false);

            StartPage.ToValidateEmailPage(
                    driver,
                    testData)
                // ReSharper disable once StringLiteralTypo
                .ValidationCode("aaaaaa")
                .SubmitFail();
        }
    }
}
