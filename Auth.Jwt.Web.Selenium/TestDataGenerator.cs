namespace Auth.Jwt.Web.Selenium
{
    using System.Collections;
    using System.Collections.Generic;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;

    /// <summary>
    ///     Generator for <see cref="Xunit.ClassDataAttribute" /> of <see cref="Xunit" />.
    /// </summary>
    public class TestDataGenerator : IEnumerable<object[]>
    {
        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<object[]> GetEnumerator()
        {
            const string userName = "userName";
            const string password = "password";
            const string url = "http://localhost:5000";

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            yield return new object[]
            {
                new TestData(
                    new ChromeDriver(chromeOptions),
                    userName,
                    password,
                    url)
            };

            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");
            yield return new object[]
            {
                new TestData(
                    new FirefoxDriver(firefoxOptions),
                    userName,
                    password,
                    url)
            };

            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--headless");
            yield return new object[]
            {
                new TestData(
                    new EdgeDriver(edgeOptions),
                    userName,
                    password,
                    url)
            };
        }
    }
}
