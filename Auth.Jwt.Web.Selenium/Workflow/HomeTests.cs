namespace Auth.Jwt.Web.Selenium.Workflow
{
    using Auth.Jwt.Web.Selenium.Pages;
    using Xunit;

    public class HomeTests : TestBase
    {
        [Theory]
        [MemberData(
            nameof(TestDataGenerator.TestData),
            MemberType = typeof(TestDataGenerator),
            DisableDiscoveryEnumeration = true)]
        public void RedirectToSignIn(string driverName)
        {
            var (_, driver) = this.Init(
                driverName,
                false,
                false);
            SignInPage.Create(driver);
        }
    }
}
