﻿using Microsoft.EntityFrameworkCore;
using Stray_Home_Domain.Entities;
using Stray_Home_Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray_Home_Infrastructure.Data
{
    public class StrayHomeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<UserShopItem> UserShopItems { get; set; }
        public DbSet<UserAnimal> UserAnimals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Shelter> Shelters { get; set; }

        public StrayHomeContext(DbContextOptions<StrayHomeContext> options)
      : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ShelterConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new ShopItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserShopItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserAnimalConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

        }
    }
}
