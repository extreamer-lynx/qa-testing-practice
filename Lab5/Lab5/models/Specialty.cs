using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.models
{
    public class Specialty
    {
        public Specialty(IConfigurationRoot configuration)
        {
            EditedName = configuration.GetSection("specialty").GetValue<string>("editedSpecialtyName");
            NewName = configuration.GetSection("specialty").GetValue<string>("newSpecialtyName");
        }

        public string EditedName { get; set; }
        public string NewName { get; set; }
    }
}
