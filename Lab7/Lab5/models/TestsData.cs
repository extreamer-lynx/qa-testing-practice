using System;
namespace Lab5.models
{
	public class TestsData
	{
		public TestsData()
		{
		}

		public static string[] SpecialtyNames => new string[] { "Name1", "AnoutherName", "AndAnoutherName", "AndTheLastName" };
		public static string[] PetTypesNames => new string[] { "Name1", "AnoutherName", "AndAnoutherName", "AndTheLastName" };
		public static Owner[] Owners => new Owner[] { new Owner("name", "lastName", "address", "city", "0000000000") };
		public static Veterenar[] Veterenars => new Veterenar[] { new Veterenar("name", "lastName"), new Veterenar("name46", "lastNameiuou545") };

	}
}

