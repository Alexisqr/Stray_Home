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
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(n => n.ID);
            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Text);
            builder.Property(n => n.PublicationDate);
            builder.HasOne(n => n.Shelter)
                .WithMany()
                .HasForeignKey(n => n.ShelterID);
          
        }
    }
}
