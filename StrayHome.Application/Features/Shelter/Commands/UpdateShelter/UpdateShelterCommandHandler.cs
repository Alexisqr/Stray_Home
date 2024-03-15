using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateShelter
{
    public class UpdateShelterCommandHandler : IRequestHandler<UpdateShelterCommand, Shelter>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateShelterCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Shelter> Handle(UpdateShelterCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _context.Shelters.FirstAsync(p => p.ID == request.ID);
            if (ToUpdate == null)
            {
                throw new Exception();
            }
            //var administratorExists = await _context.Users.AnyAsync(s => s.ID == ToUpdate.AdministratorID);

            //if (!administratorExists)
            //{
            //    throw new Exception($"User with ID {ToUpdate.AdministratorID} not found");
            //}
            var propertiesToUpdate = typeof(UpdateShelterCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(Shelter).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }

            var shelter = await _context.Shelters.FirstOrDefaultAsync(p => p.ID == ToUpdate.ID);
            shelter.Name = ToUpdate.Name;
            shelter.Address = ToUpdate.Address;
            shelter.ContactInfo = ToUpdate.ContactInfo;
            await _context.SaveChangesAsync();

            return shelter;
        }
    }
}

