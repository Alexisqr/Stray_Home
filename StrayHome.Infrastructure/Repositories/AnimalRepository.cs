using Azure.Core;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using StrayHome.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Infrastructure.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly StrayHomeContext _context;

        public AnimalRepository(StrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Animal> CreateAnimal(Animal toCreate)
        {
            _context.Animals.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteAnimal(Guid animalId)
        {
            var hopItem = _context.Animals
                .FirstOrDefault(p => p.ID == animalId);

            if (hopItem is null) return;

            _context.Animals.Remove(hopItem);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Animal>> GetAllAnimal()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<Animal> GetAnimalById(Guid animalId)
        {
            return await _context.Animals.FirstAsync(p => p.ID == animalId);
        }

        public async Task<Animal> UpdateAnimal(Animal toCreate)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(p => p.ID == toCreate.ID);
            animal.Name = toCreate.Name;
            animal.Description = toCreate.Description;
            animal.IsAvailableForAdoption = toCreate.IsAvailableForAdoption;
            animal.ShelterID = toCreate.ShelterID;
            animal.Photos = toCreate.Photos;
            await _context.SaveChangesAsync();

            return animal;
        }
    }
}
