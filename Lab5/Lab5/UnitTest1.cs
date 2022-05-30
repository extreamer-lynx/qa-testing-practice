using Lab5.models;
using Lab5.PageObject;
using Microsoft.Extensions.Configuration;

namespace Lab5;

public class UnitTest1 : TestsBase
{
    public Specialty SpecialtyData { get; set; }
    public Owner NewOwner { get; set; }
    public PetType PetTypeData { get; set; }
    public Veterenars VeterenarData { get; set; }


    private void GetTestData()
    {
        var Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("TestData.json", optional: false, reloadOnChange: true)
            .Build();

        SpecialtyData = new Specialty(Configuration);
        Configuration.GetSection("specialty").Bind(SpecialtyData);

        NewOwner = new Owner(Configuration);
        Configuration.GetSection("owners").Bind(NewOwner);

        PetTypeData = new PetType(Configuration);
        Configuration.GetSection("petType").Bind(PetTypeData);

        VeterenarData = new Veterenars(Configuration);
        Configuration.GetSection("veterenarian").Bind(VeterenarData);

    }

    [SetUp]
    public void SetUp()
    {
        GetTestData();
    }

    [Test]
    public void AddNewVeterinarTest()
    {
        var newVet = VeterenarData.AddedVet;
        var pages = new Pages(driver);

        pages.Home.GoToAddNewVeterinarPage();
        pages.AddNewVeterinar.AddNewVet(newVet.Name, newVet.LastName);

        Assert.That(pages.Veterinars.GetLastVeterenarName(), Is.EqualTo($"{newVet.Name} {newVet.LastName}"));
    }


    [Test]
    public void EditLastVeterinarTest()
    {
        var newVet = VeterenarData.EditedVet;

        var pages = new Pages(driver);

        pages.Home.GoToVeterinarsPage();
        pages.Veterinars.GoToEditLastVeterinar();
        pages.EditVeterinar.EditVeterinar(newVet.LastName, newVet.Name);

        Assert.That(pages.Veterinars.GetFirstVeterenarName(), Is.EqualTo($"{newVet.Name} {newVet.LastName}"));
    }

    [Test]
    public void DeleteLastVeterinarTest()
    {
        var pages = new Pages(driver);
        pages.Home.GoToVeterinarsPage();
        var deletedName = pages.Veterinars.GetFirstVeterenarName();
        pages.Veterinars.DeleteFirstVeterinar();
        Thread.Sleep(500);
        Assert.That(deletedName, Is.Not.EqualTo(pages.Veterinars.GetFirstVeterenarName()));
    }

    [Test]
    public void AddNewOwnerTest()
    {
        var newOwner = NewOwner;

        var pages = new Pages(driver);
        pages.Home.GoToAddOwnerPage();
        pages.AddNewOwner.AddNewOwner(newOwner.Name, newOwner.LastName, newOwner.Address, newOwner.City, newOwner.Number);

        Assert.That(pages.Owner.GetLastOwner(), Is.EqualTo($"{newOwner.Name} {newOwner.LastName}"));
    }

    [Test]
    public void AddNewPetTypesTest()
    {
        var name = PetTypeData.NewPetTypeName;
        
        var pages = new Pages(driver);

        pages.Home.GoToPetTypesPage();
        pages.PetType.AddPetTypes(name);

        Assert.That(name, Is.EqualTo(pages.PetType.GetPetTypes()));
    }

    [Test]
    public void EditFirstPetTypesTest()
    {
        int index = 1;
        var name = PetTypeData.EditedPetTypeName;
        var pages = new Pages(driver);

        pages.Home.GoToPetTypesPage();
        var oldName = pages.PetType.GetPetTypes(index);
        pages.PetType.EditPetTypes(name);
        Assert.Multiple(() =>
        {
            Assert.That(name, Is.EqualTo(pages.PetType.GetPetTypes(index)));
            Assert.That(oldName, Is.Not.EqualTo(pages.PetType.GetPetTypes(index)));
        });
    }

    [Test]
    public void DeleteFirstPetTypesTest()
    {
        var pages = new Pages(driver);

        pages.Home.GoToPetTypesPage();
        var oldName = pages.PetType.GetPetTypes(1);
        pages.PetType.DeletePetTypes();

        Assert.That(oldName, Is.Not.EqualTo(pages.PetType.GetPetTypes(1)));
    }

    [Test]
    public void AddNewSpecialityTest()
    {
        var name = SpecialtyData.NewName;
        var pages = new Pages(driver);

        pages.Home.GoToSpecialityPage();
        pages.Speciality.AddSpeciality(name);

        Assert.That(name, Is.EqualTo(pages.Speciality.GetSpeciality()));
    }

    [Test]
    public void EditFirstSpecialityTest()
    {
        int index = 1;
        var name = SpecialtyData.EditedName;
        var pages = new Pages(driver);

        pages.Home.GoToSpecialityPage();
        var oldName = pages.Speciality.GetSpeciality(index);
        pages.Speciality.EditSpeciality(name, index);
        Assert.Multiple(() =>
        {
            Assert.That(name, Is.EqualTo(pages.Speciality.GetSpeciality(index)));
            Assert.That(oldName, Is.Not.EqualTo(pages.Speciality.GetSpeciality(index)));
        });
    }

    [Test]
    public void DeleteSecondSpecialityTest()
    {
        int index = 2;
        var pages = new Pages(driver);

        pages.Home.GoToSpecialityPage();
        var oldName = pages.Speciality.GetSpeciality(index);
        pages.Speciality.DeleteSpeciality(index);

        Assert.That(oldName, Is.Not.EqualTo(pages.Speciality.GetSpeciality(index)));
    }
}