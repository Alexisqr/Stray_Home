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
    public class UserRepository : IUserRepository 
    {
        private readonly StrayHomeContext _context;

        public UserRepository(StrayHomeContext context)
        {
            _context = context;
        }
        
      
       
        public async Task<ICollection<User>> GetAllUser()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> GetUserById(Guid userid)
        {
            try
            {
                User? user = await _context.Users.FirstOrDefaultAsync(p => p.ID == userid);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }      
        public async Task<User> CreateUser(User toCreate)
        {
            try
            {
                _context.Users.Add(toCreate);
                _context.SaveChanges();
                return toCreate;
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> UpdateUser(User toUpdate)
        {
            try
            {
                _context.Entry(toUpdate).State = EntityState.Modified;
                _context.SaveChanges();
                return toUpdate;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteUser(Guid userid)
        {
            try
            {
                User? user = _context.Users.Find(userid);

                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
