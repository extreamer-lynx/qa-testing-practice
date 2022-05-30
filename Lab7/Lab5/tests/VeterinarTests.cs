using System;
using NUnit.Allure.Attributes;
using Lab5.models;
using NUnit.Allure.Core;

namespace Lab5.tests
{

    [TestFixture]
    [AllureNUnit]
    [Explicit]
    [Parallelizable]
    public class VeterinarTests : TestsBase
	{

        [Test]
        [AllureStory]
        [AllureTag("AddNewVeterinarTest")]
        [TestCaseSource(typeof(TestsData), nameof(TestsData.Veterenars))]
        public void AddNewVeterinarTest(Veterenar newVet)
        {
            var pages = new Pages(driver);

            pages.Home.GoToAddNewVeterinarPage();
            pages.AddNewVeterinar.AddNewVet(newVet.Name, newVet.LastName);

            SaveScreenshot();

            Assert.That(pages.Veterinars.GetLastVeterenarName(), Is.EqualTo($"{newVet.Name} {newVet.LastName}"));
        }

        [Test]
        [AllureStory]
        [AllureTag("EditLastVeterinarTest")]
        [TestCaseSource(typeof(TestsData), nameof(TestsData.Veterenars))]
        public void EditLastVeterinarTest(Veterenar newVet)
        {
            var pages = new Pages(driver);

            pages.Home.GoToVeterinarsPage();
            pages.Veterinars.GoToEditLastVeterinar();
            pages.EditVeterinar.EditVeterinar(newVet.LastName, newVet.Name);

            SaveScreenshot();

            Assert.That(pages.Veterinars.GetFirstVeterenarName(), Is.EqualTo($"{newVet.Name} {newVet.LastName}"));
        }

        [Test]
        [AllureStory]
        [AllureTag("DeleteLastVeterinarTest")]
        public void DeleteLastVeterinarTest()
        {
            var pages = new Pages(driver);
            pages.Home.GoToVeterinarsPage();
            var deletedName = pages.Veterinars.GetFirstVeterenarName();
            pages.Veterinars.DeleteFirstVeterinar();
            Thread.Sleep(500);

            SaveScreenshot();

            Assert.That(deletedName, Is.Not.EqualTo(pages.Veterinars.GetFirstVeterenarName()));
        }
    }
}

