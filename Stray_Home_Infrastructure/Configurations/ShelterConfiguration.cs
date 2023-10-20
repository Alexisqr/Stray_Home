using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stray_Home_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray_Home_Infrastructure.Configurations
{
    public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Address);
            builder.Property(s => s.ContactInfo);
            builder.HasOne(s => s.Administrator)
                .WithMany()
                .HasForeignKey(s => s.AdministratorID);
        }
    }
}
