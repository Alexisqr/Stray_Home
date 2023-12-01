using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Featuresb.Commands.DeleteUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteUserAnimal
{
    public class DeleteUserAnimalCommandHandler: IRequestHandler<DeleteUserAnimalCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteUserAnimalCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserAnimalCommand request, CancellationToken cancellationToken)
        { 
            var toDelete = await _context.UserAnimals.FirstAsync(p => p.AnimalID == request.AnimalID);

            if (toDelete == null)
            {
                 throw new Exception();
            }

            var hopItem = _context.UserAnimals
             .FirstOrDefault(p => p.AnimalID == toDelete.AnimalID);

            _context.UserAnimals.Remove(hopItem);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

    }
}
