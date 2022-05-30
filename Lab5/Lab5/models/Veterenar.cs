using Microsoft.Extensions.Configuration;

namespace Lab5.models
{
    public class Veterenars
    {
        public Veterenars(IConfigurationRoot configuration)
        {
            var owners = configuration.GetSection("veterenar").GetChildren();

            EditedVet = new Veterenar(owners.ToList()[0]);
            AddedVet = new Veterenar(owners.ToList()[1]);

        }

        public Veterenar EditedVet { get; set; }
        public Veterenar AddedVet { get; set; }
    }

    public class Veterenar
    {
        public Veterenar(IConfigurationSection configuration)
        {
            Name = configuration.GetValue<string>("name");
            LastName = configuration.GetValue<string>("lastName");
        }

        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
