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
    public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Address);
            builder.Property(s => s.ContactInfo);
           
        }
    }
}
