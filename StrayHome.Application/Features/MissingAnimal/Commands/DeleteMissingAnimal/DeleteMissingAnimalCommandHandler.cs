using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteComment;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteMissingAnimal
{
    public class DeleteMissingAnimalCommandHandler : IRequestHandler<DeleteMissingAnimalCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteMissingAnimalCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMissingAnimalCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _context.MissingAnimals.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null||toDelete.AdType==AdType.User)
            {
                throw new Exception();
            }

            _context.MissingAnimals.Remove(toDelete);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
