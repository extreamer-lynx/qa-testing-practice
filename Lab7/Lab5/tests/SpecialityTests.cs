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
	public class SpecialityTests : TestsBase
	{

        [Test]
        [AllureStory]
        [AllureTag("AddNewSpecialityTest")]
        [TestCaseSource(typeof(TestsData), nameof(TestsData.SpecialtyNames))]
        public void AddNewSpecialityTest(string name)
        {
            var pages = new Pages(driver);

            pages.Home.GoToSpecialityPage();
            pages.Speciality.AddSpeciality(name);

            SaveScreenshot();

            Assert.That(name, Is.EqualTo(pages.Speciality.GetSpeciality()));
        }

        [Test]
        [AllureStory]
        [AllureTag("EditFirstSpecialityTest")]
        [TestCaseSource(typeof(TestsData), nameof(TestsData.SpecialtyNames))]
        public void EditFirstSpecialityTest(string name)
        {
            int index = 1;
            var pages = new Pages(driver);

            pages.Home.GoToSpecialityPage();
            var oldName = pages.Speciality.GetSpeciality(index);
            pages.Speciality.EditSpeciality(name, index);

            SaveScreenshot();

            Assert.Multiple(() =>
            {
                Assert.That(name, Is.EqualTo(pages.Speciality.GetSpeciality(index)));
                Assert.That(oldName, Is.Not.EqualTo(pages.Speciality.GetSpeciality(index)));
            });
        }

        [Test]
        [AllureStory]
        [AllureTag("DeleteSecondSpecialityTest")]
        public void DeleteSecondSpecialityTest()
        {
            int index = 2;
            var pages = new Pages(driver);

            pages.Home.GoToSpecialityPage();
            var oldName = pages.Speciality.GetSpeciality(index);
            pages.Speciality.DeleteSpeciality(index);

            SaveScreenshot();

            Assert.That(oldName, Is.Not.EqualTo(pages.Speciality.GetSpeciality(index)));
        }
    }
}

