using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Infrastructure.Configurations
{
    public class ShelterAdminConfiguration : IEntityTypeConfiguration<ShelterAdmin>
    {
        public void Configure(EntityTypeBuilder<ShelterAdmin> builder)
        {
            builder.HasKey(si => si.ID);

            builder.HasOne(uo => uo.Administrator)
                .WithMany()
                .HasForeignKey(uo => uo.AdministratorID)
                .IsRequired();

            builder.HasOne(uo => uo.Shelter)
                .WithMany()
                .HasForeignKey(uo => uo.ShelterID)
                .IsRequired();

        }
    }
}

