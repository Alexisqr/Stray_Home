using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdUserShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdShelterAdmin
{
    public class GetByIdShelterAdminQueryHandler : IRequestHandler<GetByIdShelterAdminQuery, ShelterAdmin>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdShelterAdminQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<ShelterAdmin> Handle(GetByIdShelterAdminQuery request, CancellationToken cancellationToken)
        {
            return await _context.ShelterAdmins.FirstAsync(p => p.ID == request.ID);
        }
    }
}
