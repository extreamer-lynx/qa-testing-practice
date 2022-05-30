using Allure.Commons;
using Lab5.models;
using Microsoft.Extensions.Configuration;
using NUnit.Allure.Attributes;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab5.tests
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

        protected void SaveScreenshot()
        {
            var path = "/Users/vladfrancuk/Desktop/QA/Lab6/results/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imageName = $"Result_{DateTime.Now:yyyy-MM-dd_HH-mm-ss.ffff}.png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path + imageName);
            AllureLifecycle.Instance.AddAttachment(path, "Name");
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                SaveScreenshot();
            }
            driver.Quit();
        }
    }
}