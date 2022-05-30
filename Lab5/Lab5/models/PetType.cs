using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.models
{
    public class PetType
    {
        public PetType(IConfigurationRoot configuration)
        {
            EditedPetTypeName = configuration.GetSection("petType").GetValue<string>("editedPetTypeName");
            NewPetTypeName = configuration.GetSection("petType").GetValue<string>("newPetTypeName");
        }

        public string EditedPetTypeName { get; set; }
        public string NewPetTypeName { get; set; }
    }
}
