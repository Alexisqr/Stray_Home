using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Infrastructure.Configurations
{
    public class UserShopItemConfiguration : IEntityTypeConfiguration<UserShopItem>
    {
        public void Configure(EntityTypeBuilder<UserShopItem> builder)
        {
            builder.HasKey(si => si.ID);

            builder.Property(uo => uo.OrderDate).IsRequired();

            builder.HasOne(uo => uo.User)
                .WithMany()
                .HasForeignKey(uo => uo.UserID)
                .IsRequired();

            builder.HasOne(uo => uo.ShopItem)
                .WithMany()
                .HasForeignKey(uo => uo.ShopItemID)
                .IsRequired();

        }
    }
}
