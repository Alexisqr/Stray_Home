using MediatR;
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
    internal class GetByIdAnimalQueryHandler : IRequestHandler<GetByIdAnimalQuery, Animal>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetByIdAnimalQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Animal> Handle(GetByIdAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _animalRepository.GetAnimalById(request.ID);
        }


    }
}
