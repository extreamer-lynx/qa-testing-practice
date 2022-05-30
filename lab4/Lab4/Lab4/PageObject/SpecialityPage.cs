using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab4.PageObject
{
	public class SpecialityPage
	{
		private IWebDriver driver;
		protected WebDriverWait webDriverWait;

        private static By EditByIndex(int index) => By.CssSelector($"tr:nth-child({index}) .editSpecialty");
        private static By GetByIndex(int index) => (index == 0) ? By.CssSelector("tr:last-child input") : By.CssSelector($"tr:nth-child({index}) input");
        private static By DeleteByIndex(int index) => By.CssSelector($"tr:nth-child({index}) .deleteSpecialty");

        public SpecialityPage(IWebDriver driver)
		{
			this.driver = driver;
			if (!driver.Url.EndsWith("/specialties"))
			{
				throw new Exception("This is not Speciality page, current page is: " + driver.Url);
			}
			webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
		}

        public string GetSpeciality(int index = 0)
        {
            var petTypeName = webDriverWait.Until(driver => driver.FindElement(GetByIndex(index)));
            return petTypeName.GetAttribute("ng-reflect-model");
        }

        public void AddSpeciality(string name)
        {
            driver.FindElement(By.CssSelector(".addSpecialty")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".addSpecialty"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys(name);
            webDriverWait.Until(driver => driver.FindElement(By.CssSelector(".btn:nth-child(3)"))).Click();
            Thread.Sleep(200);
        }

        public void EditSpeciality(string newName, int index = 1)
        {
            driver.FindElement(EditByIndex(index)).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(newName);
            driver.FindElement(By.CssSelector(".updateSpecialty")).Click();
            Thread.Sleep(200);
        }

        public void DeleteSpeciality(int index = 2)
        {
            driver.FindElement(DeleteByIndex(index)).Click();
            Thread.Sleep(200);
        }

    }
}

