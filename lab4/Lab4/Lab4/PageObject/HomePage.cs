using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab4.PageObject
{
	public class HomePage
	{
        protected WebDriverWait webDriverWait;
        protected IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            if (!driver.Url.EndsWith("/petclinic/"))
            {
                throw new Exception("This is not Home Page, current page is: " + driver.Url);
            }
            this.webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public AddNewVeterinarPage GoToAddNewVeterinarPage()
        {
            driver.FindElement(By.CssSelector(".vetsTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(2) span:nth-child(2)")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/add"));
            return new AddNewVeterinarPage(driver);
        }

        public AddNewOwnerPage GoToAddOwnerPage()
        {
            driver.FindElement(By.CssSelector(".ownerTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(2) span:nth-child(2)")).Click();

            webDriverWait.Until(driver => driver.Url.EndsWith("/owners/add"));

            return new AddNewOwnerPage(driver);
        }

        public VeterinarsPage GoToVeterinarsPage()
        {
            driver.FindElement(By.CssSelector(".vetsTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(1) > a")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/vets"));
            return new VeterinarsPage(driver);
        }

        public PetTypePage GoToPetTypesPage()
        {
            driver.FindElement(By.CssSelector("li:nth-child(4) span:nth-child(2)")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/pettypes"));
            return new PetTypePage(driver);
        }

        public SpecialityPage GoToSpecialityPage()
        {
            driver.FindElement(By.CssSelector("li:nth-child(5) span:nth-child(2)")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/specialties"));
            return new SpecialityPage(driver);
        }
    }
}

