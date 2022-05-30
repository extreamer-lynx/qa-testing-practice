using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab4.PageObject
{
	public class EditVeterinarPage
	{
		protected IWebDriver driver;

		public WebDriverWait webDriverWait;

		public EditVeterinarPage(IWebDriver driver)
		{
			this.driver = driver;
			if (!driver.Url.EndsWith("/edit"))
			{
				throw new Exception("This is not Edit Veterinars Page, current page is: " + driver.Url);
			}
			this.webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
		}

		public VeterinarsPage EditVeterinar(string lastName, string firstName)
        {
			driver.FindElement(By.Id("firstName")).Click();
			driver.FindElement(By.Id("firstName")).Clear();
			driver.FindElement(By.Id("firstName")).SendKeys(firstName);
			driver.FindElement(By.Id("lastName")).Click();
			driver.FindElement(By.Id("lastName")).Clear();
			driver.FindElement(By.Id("lastName")).SendKeys(lastName);
			driver.FindElement(By.CssSelector(".saveVet")).Click();

			webDriverWait.Until(driver => driver.Url.EndsWith("/vets"));
			return new VeterinarsPage(driver);
        }
	}
}

