using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stray_Home_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray_Home_Infrastructure.Configurations
{
    public class UserShopItemConfiguration : IEntityTypeConfiguration<UserShopItem>
    {
        public void Configure(EntityTypeBuilder<UserShopItem> builder)
        {
            builder.HasKey(uo => new { uo.UserID, uo.ShopItemID });
            builder.HasOne(uo => uo.User)
                .WithMany()
                .HasForeignKey(uo => uo.UserID);
            builder.HasOne(uo => uo.ShopItem)
                .WithMany()
                .HasForeignKey(uo => uo.ShopItemID);
            builder.Property(uo => uo.OrderDate);
        }
    }
}
