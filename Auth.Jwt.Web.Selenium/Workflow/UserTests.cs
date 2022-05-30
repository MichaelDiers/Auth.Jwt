namespace Auth.Jwt.Web.Selenium.Workflow
{
    using Auth.Jwt.Web.Selenium.Pages;
    using Xunit;

    public class UserTests : TestBase
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

            StartPage.ToUserIndexPage(
                    driver,
                    testData)
                .Logout();
        }
    }
}
