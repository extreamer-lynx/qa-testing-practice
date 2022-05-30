using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab5.PageObject
{
	public class AddNewVeterinarPage
	{
		protected IWebDriver driver;

		public AddNewVeterinarPage(IWebDriver driver)
		{
			this.driver = driver;
            if (!driver.Url.EndsWith("vets/add"))
            {
                throw new Exception("This is not Vets add, current page is: " + driver.Url);
            }
		}


		public VeterinarsPage AddNewVet(string firstName, string lastName)
        {
            Helpers.CrearAndType(driver.FindElement(By.Id("firstName")), firstName);
            Helpers.CrearAndType(driver.FindElement(By.Id("lastName")), lastName);

            driver.FindElement(By.Id("specialties")).Click();
            {
                var dropdown = driver.FindElement(By.Id("specialties"));
                var selectElement = new SelectElement(dropdown);
                selectElement.SelectByValue("0: Object");
            }
            driver.FindElement(By.CssSelector(".saveVet")).Click();

            return new VeterinarsPage(driver);
        }
    }
}

