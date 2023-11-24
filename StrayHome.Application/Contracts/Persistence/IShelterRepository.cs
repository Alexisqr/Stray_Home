using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IShelterRepository
    {
        Task<ICollection<Shelter>> GetAllShelter();

        Task<Shelter> GetShelterById(Guid shelterId);

        Task<Shelter> CreateShelter(Shelter toCreate);

        Task<Shelter> UpdateShelter(Shelter toUpdate);

        Task DeleteShelter(Guid shelterId);
    }
}
