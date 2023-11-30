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

namespace StrayHome.Application.Features.Commands.UpdateAnimal
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, Animal>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateAnimalCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Animal> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _context.Animals.FirstAsync(p => p.ID == request.ID);

            if (ToUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateAnimalCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(Animal).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }
        
            var animal = await _context.Animals.FirstOrDefaultAsync(p => p.ID == ToUpdate.ID);
            animal.Name = ToUpdate.Name;
            animal.Description = ToUpdate.Description;
            animal.IsAvailableForAdoption = ToUpdate.IsAvailableForAdoption;
            animal.ShelterID = ToUpdate.ShelterID;
            animal.Photos = ToUpdate.Photos;
            await _context.SaveChangesAsync();

            return animal;
        }


    }
}
