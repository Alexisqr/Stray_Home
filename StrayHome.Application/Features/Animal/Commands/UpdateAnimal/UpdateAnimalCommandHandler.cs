using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateShopItem;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
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
                    if(property.Name=="TypeAnimal")
                    {
                        sourceValue = sourceValue == "Cat" ? TypeAnimal.Cat : sourceValue == "Dog" ? TypeAnimal.Dog : TypeAnimal.Else;
                    }
                    if (property.Name == "Sex")
                    {
                        sourceValue = sourceValue == "M" ? GenderAnimal.M : sourceValue == "F" ? GenderAnimal.F : GenderAnimal.Else;
                    }
                    var destinationProperty = typeof(Animal).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }
        
            var animal = await _context.Animals.FirstOrDefaultAsync(p => p.ID == ToUpdate.ID);
            animal.Name = ToUpdate.Name;
            animal.Description = ToUpdate.Description;
            animal.IsAvailableForAdoption = ToUpdate.IsAvailableForAdoption;
            animal.Photos = ToUpdate.Photos;
            animal.TypeAnimal = ToUpdate.TypeAnimal;
            animal.Sex = ToUpdate.Sex ;
            animal.Sterilization = ToUpdate.Sterilization;
            animal.Age = ToUpdate.Age;
            await _context.SaveChangesAsync();

            return animal;
        }


    }
}
