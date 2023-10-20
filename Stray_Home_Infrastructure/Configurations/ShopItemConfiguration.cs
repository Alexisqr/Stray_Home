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
    public class ShopItemConfiguration : IEntityTypeConfiguration<ShopItem>
    {
        public void Configure(EntityTypeBuilder<ShopItem> builder)
        {
            builder.HasKey(si => si.ID);
            builder.Property(si => si.Name).IsRequired();
            builder.Property(si => si.Description);
            builder.Property(si => si.Price);
            builder.Property(si => si.Photos);
            builder.Property(si => si.StockQuantity);
     
        }
    }
}
