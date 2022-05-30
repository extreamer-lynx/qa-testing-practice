using Microsoft.Extensions.Configuration;

namespace Lab5.models
{
    public class Owner
    {
        public Owner(string name, string lastName, string address, string city, string number)
        {
            Name = name;
            LastName = lastName;
            Address = address;
            City = city;
            Number = number;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
    }
}
