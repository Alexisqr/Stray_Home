using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IUserAnimalRepository
    {
        Task<ICollection<UserAnimal>> GetAllUserAnimal();

        Task<UserAnimal> GetUserAnimalById(Guid userAnimalId);

        Task<UserAnimal> CreateUserAnimal(UserAnimal toCreate);

        Task<UserAnimal> UpdateUserAnimal(UserAnimal toUpdate);

        Task DeleteUserAnimal(Guid userAnimalId);
    }
}
