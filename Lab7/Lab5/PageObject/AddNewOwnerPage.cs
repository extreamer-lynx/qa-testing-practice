using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab5.PageObject
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
			Helpers.CrearAndType(driver.FindElement(By.Id("firstName")), firstName);
			Helpers.CrearAndType(driver.FindElement(By.Id("lastName")), lastName);
			Helpers.CrearAndType(driver.FindElement(By.Id("address")), address);
			Helpers.CrearAndType(driver.FindElement(By.Id("city")), city);
			Helpers.CrearAndType(driver.FindElement(By.Id("telephone")), telephone);

			driver.FindElement(By.CssSelector(".addOwner")).Click();


			webDriverWait.Until(driver => driver.Url.EndsWith("/owners"));

			return new OwnerPage(driver);
        }
	}
}

