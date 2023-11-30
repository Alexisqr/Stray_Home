using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllShelter
{
    public class GetAllShelterQueryHandler : IRequestHandler<GetAllShelterQuery, IEnumerable<Shelter>>
    {
        private readonly IStrayHomeContext _context;

        public GetAllShelterQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shelter>> Handle(GetAllShelterQuery request, CancellationToken cancellationToken)
        {
            return await _context.Shelters.ToListAsync();
        }
    }
}

