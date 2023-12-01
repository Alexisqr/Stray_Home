using Microsoft.EntityFrameworkCore;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IStrayHomeContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<UserShopItem> UserShopItems { get; set; }
        public DbSet<UserAnimal> UserAnimals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        
        /// <summary>
        /// Saves changes.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
