using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateAnimal;
using StrayHome.Domain.DTO;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.AddListOfAnimals
{
    public class AddListOfAnimalsCommandHandler : IRequestHandler<AddListOfAnimalsCommand, IEnumerable<Animal>>
    {
        private readonly IStrayHomeContext _context;

        public AddListOfAnimalsCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Animal>> Handle(AddListOfAnimalsCommand request, CancellationToken cancellationToken)
        {
            var resultAnimals = new List<Animal>();
            var shelterAdmins = await _context.ShelterAdmins.FirstAsync(p => p.AdministratorID == request.ID);


            foreach (var animal in request.Animals)
            {
                var shelterExists = await _context.Shelters.AnyAsync(s => s.ID == shelterAdmins.ShelterID);
                if (!shelterExists)
                {
                    throw new Exception($"Shelter with ID {shelterAdmins.ShelterID} not found");
                }
                var animalCreate = new Animal
                {
                    Name = animal.Name,
                    Description = animal.Description,
                    Photos = animal.Photos,
                    IsAvailableForAdoption = animal.IsAvailableForAdoption,
                    ShelterID = shelterAdmins.ShelterID,

                };

                _context.Animals.Add(animalCreate);
                resultAnimals.Add(animalCreate);
            }

            await _context.SaveChangesAsync();
            return resultAnimals;
        }
    }

}
