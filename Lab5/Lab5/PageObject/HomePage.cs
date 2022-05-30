using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab5.PageObject
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

        public void GoToAddNewVeterinarPage()
        {
            driver.FindElement(By.CssSelector(".vetsTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(2) span:nth-child(2)")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/add"));
        }

        public void GoToAddOwnerPage()
        {
            driver.FindElement(By.CssSelector(".ownerTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(2) span:nth-child(2)")).Click();

            webDriverWait.Until(driver => driver.Url.EndsWith("/owners/add"));

        }

        public void GoToVeterinarsPage()
        {
            driver.FindElement(By.CssSelector(".vetsTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(1) > a")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/vets"));
        }

        public void GoToPetTypesPage()
        {
            driver.FindElement(By.CssSelector("li:nth-child(4) span:nth-child(2)")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/pettypes"));
        }

        public void GoToSpecialityPage()
        {
            driver.FindElement(By.CssSelector("li:nth-child(5) span:nth-child(2)")).Click();
            webDriverWait.Until(driver => driver.Url.EndsWith("/specialties"));
        }
    }
}

