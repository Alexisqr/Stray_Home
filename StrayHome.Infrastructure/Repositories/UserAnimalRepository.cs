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
    public class UserAnimalRepository : IUserAnimalRepository
    {
        private readonly StrayHomeContext _context;

        public UserAnimalRepository(StrayHomeContext context)
        {
            _context = context;
        }

        public async Task<UserAnimal> CreateUserAnimal(UserAnimal toCreate)
        {
            _context.UserAnimals.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteUserAnimal(Guid userAnimalId)
        {
            var hopItem = _context.UserAnimals
                .FirstOrDefault(p => p.AnimalID == userAnimalId);

            if (hopItem is null) return;

            _context.UserAnimals.Remove(hopItem);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserAnimal>> GetAllUserAnimal()
        {
            return await _context.UserAnimals.ToListAsync();
        }

        public async Task<UserAnimal> GetUserAnimalById(Guid userAnimalId)
        {
            return await _context.UserAnimals.FirstAsync(p => p.AnimalID == userAnimalId);
        }

        public async Task<UserAnimal> UpdateUserAnimal(UserAnimal toCreate)
        {
            var userAnimal = await _context.UserAnimals.FirstOrDefaultAsync(p => p.AnimalID == toCreate.AnimalID);
            userAnimal.UserID = toCreate.UserID;
            userAnimal.AnimalID = toCreate.AnimalID;
            userAnimal.SubmissionDate = toCreate.SubmissionDate;
            await _context.SaveChangesAsync();

            return userAnimal;
        }
    }
}

