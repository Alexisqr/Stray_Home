using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetShopItemById;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdAnimal
{
    public class GetByIdAnimalQueryHandler : IRequestHandler<GetByIdAnimalQuery, Animal>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdAnimalQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Animal> Handle(GetByIdAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _context.Animals.FirstAsync(p => p.ID == request.ID);
        }

    }
}
