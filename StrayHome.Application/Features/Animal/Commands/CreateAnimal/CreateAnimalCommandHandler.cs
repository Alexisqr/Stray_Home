using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Animal>
    {
        private readonly IAnimalRepository _animalRepository;

        public CreateAnimalCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Animal> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = new Animal
            {
                Name = request.Name,
                Description = request.Description,
                Photos = request.Photos,
                IsAvailableForAdoption = request.IsAvailableForAdoption,
                ShelterID = request.ShelterID,

            };

            return await _animalRepository.CreateAnimal(animal);
        }
    }
}
