using Microsoft.Extensions.Configuration;

namespace Lab5.models
{
    public class Veterenar
    {
        public Veterenar(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
