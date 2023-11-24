using MediatR;
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
        private readonly IShelterRepository _shelterRepository;

        public GetAllShelterQueryHandler(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public async Task<IEnumerable<Shelter>> Handle(GetAllShelterQuery request, CancellationToken cancellationToken)
        {
            return await _shelterRepository.GetAllShelter();
        }
    }
}

