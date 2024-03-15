using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateShelterAdmin
{
    public class CreateShelterAdminCommand : IRequest<ShelterAdmin>
    {
        public Guid AdministratorID { get; set; }
        public Guid ShelterID { get; set; }
    }
}
