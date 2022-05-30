using Lab4.PageObject;

namespace Lab4;

public class UnitTest1 : TestsBase
{
    [Test]
    public void AddNewVeterinarTest()
    {
        var firstName = Faker.Name.First();
        var lastName = Faker.Name.Last();

        var homePage = new HomePage(driver);
        AddNewVeterinarPage addNewVeterinarPage = homePage.GoToAddNewVeterinarPage();
        VeterinarsPage veterinarsPage = addNewVeterinarPage.AddNewVet(firstName, lastName);

        Assert.That(veterinarsPage.GetLastVeterenarName(), Is.EqualTo($"{firstName} {lastName}"));
    }


    [Test]
    public void EditLastVeterinarTest()
    {
        var firstName = Faker.Name.First();
        var lastName = Faker.Name.Last();

        var homePage = new HomePage(driver);
        var vetPage = homePage.GoToVeterinarsPage();
        var newVetPage = vetPage.GoToEditLastVeterinar().EditVeterinar(lastName, firstName);
        var newName = newVetPage.GetFirstVeterenarName();

        Assert.That(newName, Is.EqualTo($"{firstName} {lastName}"));
    }

    [Test]
    public void DeleteLastVeterinarTest()
    {
        var homePage = new HomePage(driver);
        var vetPage = homePage.GoToVeterinarsPage();
        var deletedName = vetPage.GetFirstVeterenarName();
        var newVetPage = vetPage.DeleteFirstVeterinar();
        Thread.Sleep(500);
        Assert.That(deletedName, Is.Not.EqualTo(newVetPage.GetFirstVeterenarName()));
    }

    [Test]
    public void AddNewOwnerTest()
    {
        var firstName = Faker.Name.First();
        var lastName = Faker.Name.Last();

        var homePage = new HomePage(driver);
        AddNewOwnerPage addNewOwnerPage = homePage.GoToAddOwnerPage();
        OwnerPage ownersPage = addNewOwnerPage.AddNewOwner(firstName, lastName, Faker.Address.StreetAddress(), Faker.Address.City(), "0977777777");

        Assert.That(ownersPage.GetLastOwner(), Is.EqualTo($"{firstName} {lastName}"));
    }

    [Test]
    public void AddNewPetTypesTest()
    {
        var name = Faker.Name.Middle();
        var homePage = new HomePage(driver);
        var petTypesPage = homePage.GoToPetTypesPage();
        petTypesPage.AddPetTypes(name);

        Assert.That(name, Is.EqualTo(petTypesPage.GetPetTypes()));
    }

    [Test]
    public void EditFirstPetTypesTest()
    {
        var name = Faker.Name.Middle();
        var homePage = new HomePage(driver);
        var petTypesPage = homePage.GoToPetTypesPage();
        var oldName = petTypesPage.GetPetTypes(1);
        petTypesPage.EditPetTypes(name);
        Assert.Multiple(() =>
        {
            Assert.That(name, Is.EqualTo(petTypesPage.GetPetTypes(1)));
            Assert.That(oldName, Is.Not.EqualTo(petTypesPage.GetPetTypes(1)));
        });
    }

    [Test]
    public void DeleteFirstPetTypesTest()
    {
        var homePage = new HomePage(driver);
        var petTypesPage = homePage.GoToPetTypesPage();
        var oldName = petTypesPage.GetPetTypes(1);
        petTypesPage.DeletePetTypes();

        Assert.That(oldName, Is.Not.EqualTo(petTypesPage.GetPetTypes(1)));
    }

    [Test]
    public void AddNewSpecialityTest()
    {
        var name = Faker.Name.Middle();

        var homePage = new HomePage(driver);
        var specialityPage = homePage.GoToSpecialityPage();
        specialityPage.AddSpeciality(name);

        Assert.That(name, Is.EqualTo(specialityPage.GetSpeciality()));
    }

    [Test]
    public void EditFirstSpecialityTest()
    {
        var name = Faker.Name.Middle();
        var homePage = new HomePage(driver);
        var specialityPage = homePage.GoToSpecialityPage();
        var oldName = specialityPage.GetSpeciality(1);
        specialityPage.EditSpeciality(name);
        Assert.Multiple(() =>
        {
            Assert.That(name, Is.EqualTo(specialityPage.GetSpeciality(1)));
            Assert.That(oldName, Is.Not.EqualTo(specialityPage.GetSpeciality(1)));
        });
    }

    [Test]
    public void DeleteSecondSpecialityTest()
    {
        int index = 2;

        var homePage = new HomePage(driver);
        var petTypesPage = homePage.GoToSpecialityPage();
        var oldName = petTypesPage.GetSpeciality(index);
        petTypesPage.DeleteSpeciality(index);

        Assert.That(oldName, Is.Not.EqualTo(petTypesPage.GetSpeciality(index)));
    }
}