using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StrayHome.Domain.Entities;

namespace StrayHome.Infrastructure.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Description);
            builder.Property(a => a.Photos);
            builder.Property(a => a.IsAvailableForAdoption);
            builder.HasOne(a => a.Shelter)
                .WithMany()
                .HasForeignKey(a => a.ShelterID);
        }
    }
}
