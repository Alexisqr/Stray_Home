﻿
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class Animal
    {
        public Guid ID { get; set; }

        public string Location { get; set; }
        public TypeAnimal TypeAnimal { get; set; }
        public GenderAnimal Sex { get; set; }
        public double Age { get; set; }
        public bool Sterilization { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Photos { get; set; }
        public bool IsAvailableForAdoption { get; set; }

        public Guid ShelterID { get; set; }
        public Shelter Shelter { get; set; }
    }
}
