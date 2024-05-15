using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllComment;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllMissingAnimal
{
    public class GetAllMissingAnimalQueryHandler : IRequestHandler<GetAllMissingAnimalQuery, IEnumerable<MissingAnimal>>
    {
        private readonly IStrayHomeContext _context;

        public GetAllMissingAnimalQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MissingAnimal>> Handle(GetAllMissingAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _context.MissingAnimals.ToListAsync();
        }
    }
}
