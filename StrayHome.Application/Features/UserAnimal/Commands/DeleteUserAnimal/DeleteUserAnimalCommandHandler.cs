using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Featuresb.Commands.DeleteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteUserAnimal
{
    public class DeleteUserAnimalCommandHandler: IRequestHandler<DeleteUserAnimalCommand>
    {

        private readonly IUserAnimalRepository _userAnimalRepository;

    public DeleteUserAnimalCommandHandler(IUserAnimalRepository userAnimalRepository)
    {
         _userAnimalRepository = userAnimalRepository;
    }

    public async Task<Unit> Handle(DeleteUserAnimalCommand request, CancellationToken cancellationToken)
    {

        var toDelete = await _userAnimalRepository.GetUserAnimalById(request.AnimalID);

        if (toDelete == null)
        {
            throw new Exception();
        }

        await _userAnimalRepository.DeleteUserAnimal(toDelete.AnimalID);

        return Unit.Value;
    }

    }
}
