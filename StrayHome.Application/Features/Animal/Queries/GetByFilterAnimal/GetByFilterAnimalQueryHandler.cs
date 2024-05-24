using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdAnimal;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByFilterAnimal
{
    public class GetByFilterAnimalQueryHandler : IRequestHandler<GetByFilterAnimalQuery, IEnumerable<Animal>>
    {
        private readonly IStrayHomeContext _context;

        public GetByFilterAnimalQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Animal>> Handle(GetByFilterAnimalQuery request, CancellationToken cancellationToken)
        {

            var owners = await _context.Animals
     .Where(o =>
         (string.IsNullOrEmpty(request.Location) ||
          o.Location.Substring(0, o.Location.IndexOf(" ")) == request.Location ||
          o.Location == request.Location) &&
         (request.Sterilization == null || o.Sterilization == request.Sterilization) &&
         (string.IsNullOrEmpty(request.Sex) || o.Sex == Enum.Parse<GenderAnimal>(request.Sex)) &&
         (request.Age == null || o.Age == request.Age) &&
         (string.IsNullOrEmpty(request.TypeAnimal) || o.TypeAnimal == Enum.Parse<TypeAnimal>(request.TypeAnimal)) &&
         (string.IsNullOrEmpty(request.Shelter) || o.ShelterID == _context.Shelters.FirstOrDefault(e => e.Name == request.Shelter).ID))
     .ToListAsync();

            return owners;
        }
    }
}
