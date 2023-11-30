using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteAnimal
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteAnimalCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {

            var toDelete =  await _context.Animals.FirstAsync(p => p.ID == request.ID);
            if (toDelete == null)
            {
                throw new Exception();
            }
            var hopItem_userAnimals = _context.UserAnimals
                .FirstOrDefault(p => p.AnimalID == request.ID);

            _context.UserAnimals.Remove(hopItem_userAnimals);

       
            var hopItem = _context.Animals
                .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.Animals.Remove(hopItem);

            await _context.SaveChangesAsync();
          

            return Unit.Value;
        }
    }
}
