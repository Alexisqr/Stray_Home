using MediatR;
using StrayHome.Domain.Entities;
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

        public Guid ShelterID { get; set; }
    }
}
