using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab4.PageObject
{
	public class PetTypePage
	{
		private IWebDriver driver;
        protected WebDriverWait webDriverWait;

        private static By EditByIndex(int index) => By.CssSelector($"tr:nth-child({index}) .editPet");
        private static By GetByIndex(int index) => (index == 0) ? By.CssSelector("tr:last-child input") : By.CssSelector($"tr:nth-child({index}) input");
        private static By DeleteByIndex(int index) => By.CssSelector($"tr:nth-child({index}) .deletePet");

        public PetTypePage(IWebDriver driver)
		{
			this.driver = driver;
			if (!driver.Url.EndsWith("/pettypes"))
			{
				throw new Exception("This is not Pet Types, current page is: " + driver.Url);
			}
            this.webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public string GetPetTypes(int index = 0)
        {
            var petTypeName = webDriverWait.Until(driver => driver.FindElement(GetByIndex(index)));
            return petTypeName.GetAttribute("ng-reflect-model");
        }

        public void AddPetTypes(string name)
        {
            driver.FindElement(By.CssSelector(".addPet")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".addPet"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys(name);
            webDriverWait.Until(driver => driver.FindElement(By.CssSelector(".saveType"))).Click();
            Thread.Sleep(200);
        }

        public void EditPetTypes(string newName, int index = 1)
        {
            driver.FindElement(EditByIndex(index)).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys(newName);
            driver.FindElement(By.CssSelector(".updatePetType")).Click();
            Thread.Sleep(200);
        }

        public void DeletePetTypes(int index = 1)
        {
            driver.FindElement(DeleteByIndex(index)).Click();
            Thread.Sleep(200);
        }
    }
}

