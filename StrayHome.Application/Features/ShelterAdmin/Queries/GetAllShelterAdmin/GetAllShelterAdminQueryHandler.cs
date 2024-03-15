using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllUserShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllShelterAdmin
{
    public class GetAllShelterAdminQueryHandler : IRequestHandler<GetAllShelterAdminQuery, IEnumerable<ShelterAdmin>>
    {
        private readonly IStrayHomeContext _context;

        public GetAllShelterAdminQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShelterAdmin>> Handle(GetAllShelterAdminQuery request, CancellationToken cancellationToken)
        {
            return await _context.ShelterAdmins.ToListAsync();
        }
    }
}
