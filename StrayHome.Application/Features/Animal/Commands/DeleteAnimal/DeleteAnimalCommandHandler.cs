using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteShopItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteAnimal
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand>
    {

        private readonly IAnimalRepository _animalRepository;

        public DeleteAnimalCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _animalRepository.GetAnimalById(request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            await _animalRepository.DeleteAnimal(toDelete.ID);

            return Unit.Value;
        }
    }
}
