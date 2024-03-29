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
        private readonly IExcelProcessingService _excelProcessingService;
        public AddListOfAnimalsCommandHandler(IStrayHomeContext context, IExcelProcessingService excelProcessingService)
        {
            _context = context;
            _excelProcessingService = excelProcessingService;
        }

        public async Task<IEnumerable<Animal>> Handle(AddListOfAnimalsCommand request, CancellationToken cancellationToken)
        {
            var data = _excelProcessingService.ReadExcel(request.File);
            var animalList = new List<AnimalDto>();
            for (int i = 1; i < data.GetLength(0); i++)
            {
                var animal = new AnimalDto
                {
                    Name = data[i, 0],
                    Description = data[i, 1],
                    Photos = data[i, 2],
                    IsAvailableForAdoption = data[i, 3] == "1" ? true : false
                };

                animalList.Add(animal);
            }
            var resultAnimals = new List<Animal>();
            var shelterAdmins = await _context.ShelterAdmins.FirstAsync(p => p.AdministratorID == request.ID);


            foreach (var animal in animalList)
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
