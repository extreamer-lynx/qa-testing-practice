using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab5.PageObject
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

		public void EditVeterinar(string lastName, string firstName)
        {
			Helpers.CrearAndType(driver.FindElement(By.Id("firstName")), firstName);
			Helpers.CrearAndType(driver.FindElement(By.Id("lastName")), lastName);

			driver.FindElement(By.CssSelector(".saveVet")).Click();

			webDriverWait.Until(driver => driver.Url.EndsWith("/vets"));
        }
	}
}

