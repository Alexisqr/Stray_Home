using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUser();
        Task<User> GetUserById(Guid userid);
        Task<User> CreateUser(User toCreate);
        Task<User> UpdateUser(User toUpdate);
        Task DeleteUser(Guid userid);       
    }
}
