using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetShopItemById;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdShelter
{
    public class GetByIdShelterQueryHandler : IRequestHandler<GetByIdShelterQuery, Shelter>
    {
        private readonly IShelterRepository _shelterRepository;

        public GetByIdShelterQueryHandler(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public async Task<Shelter> Handle(GetByIdShelterQuery request, CancellationToken cancellationToken)
        {
            return await _shelterRepository.GetShelterById(request.ID);
        }


    }
}

