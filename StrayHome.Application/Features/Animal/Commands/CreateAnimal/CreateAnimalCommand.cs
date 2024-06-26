﻿using MediatR;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateAnimal
{
    public class CreateAnimalCommand : IRequest<Animal>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photos { get; set; }
        public bool IsAvailableForAdoption { get; set; }

        public string Location { get; set; }
        public string TypeAnimal { get; set; }
        public string Sex { get; set; }
        public double Age { get; set; }
        public bool Sterilization { get; set; }
        public Guid ShelterID { get; set; }
    }
}
