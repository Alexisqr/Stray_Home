using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.DTO
{
    public class AnimalDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photos { get; set; }
        public bool IsAvailableForAdoption { get; set; }
        public string Location { get; set; }
        public TypeAnimal TypeAnimal { get; set; }
        public GenderAnimal Sex { get; set; }
        public double Age { get; set; }
        public bool Sterilization { get; set; }
    }
}
