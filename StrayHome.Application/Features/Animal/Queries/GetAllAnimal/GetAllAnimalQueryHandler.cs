using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllAnimal
{
    public class GetAllAnimalQueryHandler : IRequestHandler<GetAllAnimalQuery, IEnumerable<Animal>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllAnimalQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<IEnumerable<Animal>> Handle(GetAllAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _animalRepository.GetAllAnimal();
        }
    }
}
