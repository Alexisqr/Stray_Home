using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Domain.Entities;
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

            };

            _context.Animals.Add(animal);

            await _context.SaveChangesAsync();

            return animal;
           
        }
    }
}
