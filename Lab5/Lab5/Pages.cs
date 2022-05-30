using System;
using Lab5.PageObject;
using OpenQA.Selenium;

namespace Lab5
{
	public class Pages
	{
		private IWebDriver driver;

        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AddNewOwnerPage AddNewOwner => new AddNewOwnerPage(driver);

        public HomePage Home => new HomePage(driver);

        public AddNewVeterinarPage AddNewVeterinar => new AddNewVeterinarPage(driver);

        public EditVeterinarPage EditVeterinar => new EditVeterinarPage(driver);

        public OwnerPage Owner => new OwnerPage(driver);

        public PetTypePage PetType => new PetTypePage(driver);

        public VeterinarsPage Veterinars => new VeterinarsPage(driver);

        public SpecialityPage Speciality => new SpecialityPage(driver);
    }
}

