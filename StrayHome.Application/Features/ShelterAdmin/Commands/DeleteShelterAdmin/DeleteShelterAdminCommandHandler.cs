using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteUserAnimal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteShelterAdmin
{
    public class DeleteShelterAdminCommandHandler : IRequestHandler<DeleteShelterAdminCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteShelterAdminCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteShelterAdminCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _context.ShelterAdmins.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            var hopItem = _context.ShelterAdmins
             .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.ShelterAdmins.Remove(hopItem);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}