using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdAnimal;
using StrayHome.Domain.DTO;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetFilters
{
    public class GetFiltersQueryHandler : IRequestHandler<GetFiltersQuery, FilterDto>
    {
        private readonly IStrayHomeContext _context;

        public GetFiltersQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<FilterDto> Handle(GetFiltersQuery request, CancellationToken cancellationToken)
        {
            var AllShelters = _context.Shelters.Distinct().Select(n=> n.Name);
            var AllGenderAnimal = Enum.GetValues(typeof(GenderAnimal)).Cast<GenderAnimal>().Select(t => t.ToString()).ToList();
            var AllTypeAnimal = Enum.GetValues(typeof(TypeAnimal)).Cast<TypeAnimal>().Select(t => t.ToString()).ToList();
            var AllLocations = _context.Shelters.Distinct().Select(n => n.Address);
            var filters = new FilterDto
            {
                TypeAnimal = AllTypeAnimal,
                Locations = AllLocations,
                Sex = AllGenderAnimal,
                Shelter = AllShelters
            
            };
            return filters;
        }

    }
}
