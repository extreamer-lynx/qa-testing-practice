// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class EditfirstspecialityTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void editfirstspeciality() {
    driver.Navigate().GoToUrl("https://client.sana-commerce.dev/");
    driver.Manage().Window.Size = new System.Drawing.Size(1200, 746);
    driver.FindElement(By.CssSelector("li:nth-child(5) span:nth-child(2)")).Click();
    {
      var element = driver.FindElement(By.CssSelector("li:nth-child(5) span:nth-child(2)"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    {
      var element = driver.FindElement(By.tagName("body"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element, 0, 0).Perform();
    }
    driver.FindElement(By.CssSelector("tr:nth-child(1) .editSpecialty")).Click();
    driver.FindElement(By.Id("name")).Click();
    driver.FindElement(By.Id("name")).SendKeys("radiology smth");
    driver.FindElement(By.CssSelector(".updateSpecialty")).Click();
  }
}
