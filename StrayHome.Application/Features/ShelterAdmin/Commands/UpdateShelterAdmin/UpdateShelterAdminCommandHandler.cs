using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateUserShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateShelterAdmin
{
    public class UpdateShelterAdminCommandHandler : IRequestHandler<UpdateShelterAdminCommand, ShelterAdmin>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateShelterAdminCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShelterAdmin> Handle(UpdateShelterAdminCommand request, CancellationToken cancellationToken)
        {

            var toUpdate = await _context.ShelterAdmins.FirstAsync(p => p.ID == request.ID);
            if (toUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateShelterAdminCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(ShelterAdmin).GetProperty(property.Name);
                    destinationProperty?.SetValue(toUpdate, sourceValue);
                }
            }

            var userShopItem = await _context.ShelterAdmins.FirstOrDefaultAsync(p => p.ID == toUpdate.ID);
            userShopItem.AdministratorID = toUpdate.AdministratorID;
            userShopItem.ShelterID = toUpdate.ShelterID;
            await _context.SaveChangesAsync();

            return userShopItem;
        }
    }
}
