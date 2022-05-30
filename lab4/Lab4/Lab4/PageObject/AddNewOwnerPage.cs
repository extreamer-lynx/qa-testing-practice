using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab4.PageObject
{
	public class AddNewOwnerPage
	{

		protected IWebDriver driver;
		protected WebDriverWait webDriverWait;

		public AddNewOwnerPage(IWebDriver driver)
		{
			this.driver = driver;
			if (!driver.Url.EndsWith("/owners/add"))
			{
				throw new Exception("This is not Edit Veterinars Page, current page is: " + driver.Url);
			}
			this.webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

		}

		public OwnerPage AddNewOwner(string firstName, string lastName, string address, string city, string telephone)
        {
			driver.FindElement(By.Id("firstName")).Click();
			driver.FindElement(By.Id("firstName")).SendKeys(firstName);
			driver.FindElement(By.Id("lastName")).Click();
			driver.FindElement(By.Id("lastName")).SendKeys(lastName);
			driver.FindElement(By.Id("address")).Click();
			driver.FindElement(By.Id("address")).SendKeys(address);
			driver.FindElement(By.Id("city")).Click();
			driver.FindElement(By.Id("city")).SendKeys(city);
			driver.FindElement(By.Id("telephone")).Click();
			driver.FindElement(By.Id("telephone")).SendKeys(telephone);
			driver.FindElement(By.CssSelector(".addOwner")).Click();


			webDriverWait.Until(driver => driver.Url.EndsWith("/owners"));

			return new OwnerPage(driver);
        }
	}
}

