using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Animal>
    {
        private readonly IStrayHomeContext _context;

        public CreateAnimalCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Animal> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var shelterExists = await _context.Shelters.AnyAsync(s => s.ID == request.ShelterID);
            if (!shelterExists)
            {
                throw new Exception($"Shelter with ID {request.ShelterID} not found");
            }
            var animal = new Animal
            {
                Name = request.Name,
                Description = request.Description,
                Photos = request.Photos,
                IsAvailableForAdoption = request.IsAvailableForAdoption,
                ShelterID = request.ShelterID,
                Location = _context.Shelters.FirstOrDefault(s => s.ID == request.ShelterID).Address,
                TypeAnimal = request.TypeAnimal == "Cat" ? TypeAnimal.Cat : request.TypeAnimal == "Dog" ? TypeAnimal.Dog : TypeAnimal.Else,
                Sex = request.Sex == "M" ? GenderAnimal.M : request.Sex == "F" ? GenderAnimal.F : GenderAnimal.Else,
                Sterilization = request.Sterilization,
                Age = request.Age
            };

            _context.Animals.Add(animal);

            await _context.SaveChangesAsync();

            return animal;
           
        }
    }
}
