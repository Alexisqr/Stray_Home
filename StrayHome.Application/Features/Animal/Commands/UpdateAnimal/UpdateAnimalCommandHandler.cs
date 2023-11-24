using AutoMapper;
using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateAnimal
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, Animal>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public UpdateAnimalCommandHandler(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<Animal> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _animalRepository.GetAnimalById(request.ID);
            if (ToUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateAnimalCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(Animal).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }

            await _animalRepository.UpdateAnimal(ToUpdate);


            return ToUpdate;
        }


    }
}
