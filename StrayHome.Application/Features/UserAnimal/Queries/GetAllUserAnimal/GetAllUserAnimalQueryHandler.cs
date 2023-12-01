using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllUserAnimal
{
    public class GetAllUserAnimalQueryHandler : IRequestHandler<GetAllUserAnimalQuery, IEnumerable<UserAnimal>>
    {
        private readonly IStrayHomeContext _context;

        public GetAllUserAnimalQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserAnimal>> Handle(GetAllUserAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _context.UserAnimals.ToListAsync();
        }
    }
}