using MediatR;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrayHome.Domain.Enums;

namespace StrayHome.Application.Features.Commands.CreateShelterAdmin
{
    public class CreateShelterAdminCommandHandler : IRequestHandler<CreateShelterAdminCommand, ShelterAdmin>
    {
        private readonly IStrayHomeContext _context;

        public CreateShelterAdminCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<ShelterAdmin> Handle(CreateShelterAdminCommand request, CancellationToken cancellationToken)
        {
            
            var userExists = await _context.Users.AnyAsync(s => s.ID == request.AdministratorID);

            if (!userExists)
            {
                throw new Exception($"User with ID {request.AdministratorID} not found");
            }

            var user = await _context.Users.FirstOrDefaultAsync(p => p.ID == request.AdministratorID);
            user.Role = UserRole.AdminShelter;

            var animalExists = await _context.Shelters.AnyAsync(s => s.ID == request.ShelterID);
            if (!animalExists)
            {
                throw new Exception($"Animal with ID {request.ShelterID} not found");
            }

            var shelterAdmin = new ShelterAdmin
            {
                AdministratorID = request.AdministratorID,
                ShelterID = request.ShelterID
            };

            _context.ShelterAdmins.Add(shelterAdmin);

            await _context.SaveChangesAsync();

            return shelterAdmin;
        }
    }
}