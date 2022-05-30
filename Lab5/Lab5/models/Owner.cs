using Microsoft.Extensions.Configuration;

namespace Lab5.models
{
    public class Owner
    {
        public Owner(IConfigurationRoot configuration)
        {
            var conf = configuration.GetSection("owners");
            Name = conf.GetValue<string>("name");
            LastName = conf.GetValue<string>("lastName");
            Address = conf.GetValue<string>("address");
            City = conf.GetValue<string>("city");
            Number = conf.GetValue<string>("number");
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
    }
}
