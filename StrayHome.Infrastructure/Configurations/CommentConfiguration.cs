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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Text);
            builder.Property(c => c.CreationDate);
            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserID);
        }
    }
}
