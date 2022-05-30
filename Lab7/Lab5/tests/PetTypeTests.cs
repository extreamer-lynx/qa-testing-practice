using System;
using Lab5.models;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Lab5.tests
{

    [TestFixture]
    [AllureNUnit]
    [Explicit]
    [Parallelizable]
    public class PetTypeTests : TestsBase
	{

        [Test]
        [AllureStory]
        [AllureTag("AddNewPetTypesTest")]
        [TestCaseSource(typeof(TestsData), nameof(TestsData.PetTypesNames))]
        public void AddNewPetTypesTest(string name)
        {

            var pages = new Pages(driver);

            pages.Home.GoToPetTypesPage();
            pages.PetType.AddPetTypes(name);

            SaveScreenshot();

            Assert.That(name, Is.EqualTo(pages.PetType.GetPetTypes()));
        }

        [Test]
        [AllureStory]
        [AllureTag("EditFirstPetTypesTest")]
        [TestCaseSource(typeof(TestsData), nameof(TestsData.PetTypesNames))]
        public void EditFirstPetTypesTest(string name)
        {
            int index = 1;
            var pages = new Pages(driver);

            pages.Home.GoToPetTypesPage();
            var oldName = pages.PetType.GetPetTypes(index);
            pages.PetType.EditPetTypes(name);

            SaveScreenshot();

            Assert.Multiple(() =>
            {
                Assert.That(name, Is.EqualTo(pages.PetType.GetPetTypes(index)));
                Assert.That(oldName, Is.Not.EqualTo(pages.PetType.GetPetTypes(index)));
            });
        }

        [Test]
        [AllureStory]
        [AllureTag("DeleteFirstPetTypesTest")]
        public void DeleteFirstPetTypesTest()
        {
            var pages = new Pages(driver);

            pages.Home.GoToPetTypesPage();
            var oldName = pages.PetType.GetPetTypes(1);
            pages.PetType.DeletePetTypes();

            SaveScreenshot();

            Assert.That(oldName, Is.Not.EqualTo(pages.PetType.GetPetTypes(1)));
        }
    }
}

