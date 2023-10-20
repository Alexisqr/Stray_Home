using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stray_Home_Domain.Entities;

namespace Stray_Home_Infrastructure.Configurations
{
    public class UserAnimalConfiguration : IEntityTypeConfiguration<UserAnimal>
    {
        public void Configure(EntityTypeBuilder<UserAnimal> builder)
        {
            builder.HasKey(uar => new { uar.UserID, uar.AnimalID });
            builder.HasOne(uar => uar.User)
                .WithMany()
                .HasForeignKey(uar => uar.UserID);
            builder.HasOne(uar => uar.Animal)
                .WithMany()
                .HasForeignKey(uar => uar.AnimalID);
            builder.Property(uar => uar.SubmissionDate);
          
        }
    }
}
