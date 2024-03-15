using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdShelterAdmin
{
    public class GetByIdShelterAdminQuery : IRequest<ShelterAdmin>
    {
        public Guid ID { get; set; }
    }
}
