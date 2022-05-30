using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab5
{
    public class TestsBase
    {
        public IWebDriver driver = new ChromeDriver();
        public WebDriverWait webDriverWaiter;

        public TestsBase()
        {
            webDriverWaiter = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://client.sana-commerce.dev/";
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "result");
                var imageName = $"Result_{DateTime.Now:yyyy-MM-dd_HH-mm-ss.ffff}.png";
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(path + imageName);
            }
            driver.Quit();
        }
    }
}