using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdComment;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdMissingAnimal
{
    public class GetByIdMissingAnimalQueryHandler : IRequestHandler<GetByIdMissingAnimalQuery, MissingAnimal>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdMissingAnimalQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<MissingAnimal> Handle(GetByIdMissingAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _context.MissingAnimals.FirstAsync(p => p.ID == request.ID);
        }
    }
}
