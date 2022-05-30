namespace Auth.Jwt.Web.Selenium.Pages
{
    using Auth.Jwt.Web.Extensions;
    using OpenQA.Selenium;

    internal static class StartPage
    {
        public static SignInPage ToSignInPage(IWebDriver driver)
        {
            return SignInPage.Create(driver);
        }

        public static SignUpIndexPage ToSignUpIndexPage(IWebDriver driver)
        {
            return StartPage.ToSignInPage(driver).ClickSignUpLink();
        }

        public static UserIndexPage ToUserIndexPage(IWebDriver driver, TestData testData)
        {
            return StartPage.ToValidateEmailPage(
                    driver,
                    testData)
                .ValidationCode(testData.UserName.NormalizeUserName())
                .SubmitSuccess();
        }

        public static ValidateEmailPage ToValidateEmailPage(IWebDriver driver, TestData testData)
        {
            return StartPage.ToSignInPage(driver)
                .UserName(testData.UserName)
                .Password(testData.Password)
                .SubmitSuccess(ValidateEmailPage.Create);
        }
    }
}
