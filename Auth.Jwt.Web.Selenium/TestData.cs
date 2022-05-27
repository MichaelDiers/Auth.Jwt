namespace Auth.Jwt.Web.Selenium
{
    using OpenQA.Selenium;

    public class TestData
    {
        public TestData(
            IWebDriver driver,
            string userName,
            string password,
            string url
        )
        {
            this.Driver = driver;
            this.Url = url;
            this.UserName = userName;
            this.Password = password;
        }

        public IWebDriver Driver { get; }
        public string Password { get; }
        public string Url { get; }
        public string UserName { get; }
    }
}
