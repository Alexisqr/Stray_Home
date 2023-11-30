using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Application.Features.Commands.UpdateNews;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StrayHome.Application.Features.Commands.CreateShelter
{
    public class CreateShelterCommandHandler : IRequestHandler<CreateShelterCommand, Shelter>
    {
        private readonly IStrayHomeContext _context;

        public CreateShelterCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Shelter> Handle(CreateShelterCommand request, CancellationToken cancellationToken)
        {
            var administratorExists = await _context.Users.AnyAsync(s => s.ID == request.AdministratorID);
            if (!administratorExists)
            {
                throw new Exception($"User with ID {request.AdministratorID} not found");
            }

            var shelter = new Shelter
            {
                Name = request.Name,
                Address = request.Address,
                ContactInfo = request.ContactInfo,
                AdministratorID = request.AdministratorID,

            };
            _context.Shelters.Add(shelter);

            var user = await _context.Users.FirstOrDefaultAsync(p => p.ID == request.AdministratorID);
            user.Role = UserRole.Admin;

            await _context.SaveChangesAsync();

            return shelter;
        }
    }
}