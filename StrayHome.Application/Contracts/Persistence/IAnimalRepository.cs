using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IAnimalRepository
    {
        Task<ICollection<Animal>> GetAllAnimal();

        Task<Animal> GetAnimalById(Guid animalId);

        Task<Animal> CreateAnimal(Animal toCreate);

        Task<Animal> UpdateAnimal(Animal toUpdate);

        Task DeleteAnimal(Guid animalId);
    }
}
