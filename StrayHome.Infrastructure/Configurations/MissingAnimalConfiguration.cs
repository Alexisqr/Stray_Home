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
    public class MissingAnimalConfiguration : IEntityTypeConfiguration<MissingAnimal>
    {
        public void Configure(EntityTypeBuilder<MissingAnimal> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Name);
            builder.Property(c => c.Description);
            builder.Property(c => c.Link);
            builder.Property(c => c.ImageLink);
            builder.Property(c => c.Location);

            builder.Property(u => u.AdType)
             .IsRequired()
             .HasConversion<string>();

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserID);
        }
    }
}
