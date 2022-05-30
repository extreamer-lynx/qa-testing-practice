using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab5.PageObject
{
	public class OwnerPage
	{
		private By lastOwnerName = By.CssSelector("tr:last-child > .ownerFullName");

		protected IWebDriver driver;
		protected WebDriverWait webDriverWait;

		public OwnerPage(IWebDriver driver)
		{
			this.driver = driver;
			if (!driver.Url.EndsWith("/owners"))
			{
				throw new Exception("This is not Add Owners Page, current page is: " + driver.Url);
			}
			this.webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
		}

		public string GetLastOwner()
        {
			var ownerFullName = webDriverWait.Until(driver => driver.FindElement(lastOwnerName));

			return ownerFullName.Text;
		}
	}
}

