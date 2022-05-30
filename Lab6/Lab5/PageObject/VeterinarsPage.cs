using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab5.PageObject
{
	public class VeterinarsPage
	{
		protected WebDriverWait webDriverWait;
		protected IWebDriver driver;

		private By firstVeterinarName = By.XPath("/html/body/app-root/app-vet-list/div/div/table/tbody/tr[1]/td[1]");
		private By lastVeterinarName = By.CssSelector("tr:last-child > .vetFullName");

		public VeterinarsPage(IWebDriver driver)
		{
			this.driver = driver;
			if (!driver.Url.EndsWith("/vets"))
			{
				throw new Exception("This is not Veterinars Page, current page is: " + driver.Url);
			}
			webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
		}

		public string GetFirstVeterenarName()
		{

			var vetFullName = webDriverWait.Until(driver => driver.FindElement(firstVeterinarName));

			return vetFullName.Text;
		}


		public string GetLastVeterenarName()
		{

			var vetFullName = webDriverWait.Until(driver => driver.FindElement(lastVeterinarName));

			return vetFullName.Text;
		}

		public void GoToEditLastVeterinar()
        {
			webDriverWait.Until(driver => driver.FindElement(By.XPath("//tr[@id=\'vet\']/td[3]/button"))).Click();
			webDriverWait.Until(driver => driver.Url.EndsWith("/edit"));
		}

		public void DeleteFirstVeterinar()
        {
			webDriverWait.Until(driver => driver.FindElement(By.XPath("//tr[@id=\'vet\']/td[3]/button[2]"))).Click();
			webDriverWait.Until(driver => driver.Url.EndsWith("/vets"));
		}
	}
}
