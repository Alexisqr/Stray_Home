using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdUserAnimal
{
    public class GetByIdUserAnimalQueryHandler : IRequestHandler<GetByIdUserAnimalQuery, UserAnimal>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdUserAnimalQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<UserAnimal> Handle(GetByIdUserAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _context.UserAnimals.FirstAsync(p => p.AnimalID == request.AnimalID);
        }


    }
}

