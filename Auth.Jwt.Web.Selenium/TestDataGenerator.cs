namespace Auth.Jwt.Web.Selenium
{
    using System.Collections.Generic;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;

    public class TestDataGenerator
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {nameof(ChromeDriver)};
            yield return new object[] {nameof(EdgeDriver)};
            yield return new object[] {nameof(FirefoxDriver)};
        }
    }
}
