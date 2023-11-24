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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Salt).IsRequired();
            builder.Property(u => u.Email);
            builder.Property(u => u.CreationDate);

            builder.Property(u => u.Role)
               .IsRequired()
               .HasConversion<string>();
        }
    }
}
