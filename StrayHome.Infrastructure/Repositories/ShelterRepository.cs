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
    public class ShelterRepository : IShelterRepository
    {
        private readonly StrayHomeContext _context;

        public ShelterRepository(StrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Shelter> CreateShelter(Shelter toCreate)
        {
            _context.Shelters.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteShelter(Guid shelterId)
        {
            var hopItem = _context.Shelters
                .FirstOrDefault(p => p.ID == shelterId);

            if (hopItem is null) return;

            _context.Shelters.Remove(hopItem);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Shelter>> GetAllShelter()
        {
            return await _context.Shelters.ToListAsync();
        }

        public async Task<Shelter> GetShelterById(Guid shelterId)
        {
            return await _context.Shelters.FirstAsync(p => p.ID == shelterId);
        }

        public async Task<Shelter> UpdateShelter(Shelter toCreate)
        {
            var shelter = await _context.Shelters.FirstOrDefaultAsync(p => p.ID == toCreate.ID);
            shelter.Name = toCreate.Name;
            shelter.Address = toCreate.Address;
            shelter.ContactInfo = toCreate.ContactInfo;
            shelter.AdministratorID = toCreate.AdministratorID;
            await _context.SaveChangesAsync();

            return shelter;
        }
    }
}
