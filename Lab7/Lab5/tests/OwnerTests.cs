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
    public class OwnerTests : TestsBase
	{


        [Test]
        [AllureStory]
        [AllureTag("AddNewOwnerTest")]
        [TestCaseSource(typeof(TestsData), nameof(TestsData.Owners))]
        public void AddNewOwnerTest(Owner newOwner)
        {
            var pages = new Pages(driver);
            pages.Home.GoToAddOwnerPage();
            pages.AddNewOwner.AddNewOwner(newOwner.Name, newOwner.LastName, newOwner.Address, newOwner.City, newOwner.Number);

            SaveScreenshot();

            Assert.That(pages.Owner.GetLastOwner(), Is.EqualTo($"{newOwner.Name} {newOwner.LastName}"));
        }
    }
}

