using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteShelterAdmin
{
    public class DeleteShelterAdminCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
