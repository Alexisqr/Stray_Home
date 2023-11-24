using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateShelter
{
    public class CreateShelterCommand : IRequest<Shelter>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public Guid AdministratorID { get; set; }
    }
}
