namespace Auth.Jwt.Web.Selenium
{
    public class TestData
    {
        public TestData(
            string driver,
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

        public string Driver { get; }
        public string Password { get; }
        public string Url { get; }
        public string UserName { get; }
    }
}
