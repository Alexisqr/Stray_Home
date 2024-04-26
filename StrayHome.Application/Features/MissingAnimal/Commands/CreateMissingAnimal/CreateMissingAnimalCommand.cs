using MediatR;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateMissingAnimal
{
    public class CreateMissingAnimalCommand : IRequest<MissingAnimal>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string Location { get; set; }

        public Guid UserID { get; set; }

    }
}
