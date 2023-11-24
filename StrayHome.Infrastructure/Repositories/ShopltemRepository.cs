using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using StrayHome.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Infrastructure.Repositories
{
    public class ShopltemRepository : IShopltemRepository
    {
        private readonly StrayHomeContext _context;

        public ShopltemRepository(StrayHomeContext context)
        {
            _context = context;
        }

        public async Task<ShopItem> CreateShopItem(ShopItem toCreate)
        {
            _context.ShopItems.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteShopItem(Guid shopItemId)
        {
            var hopItem = _context.ShopItems
                .FirstOrDefault(p => p.ID == shopItemId);

            if (hopItem is null) return;

            _context.ShopItems.Remove(hopItem);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ShopItem>> GetAllShopItem()
        {
            return await _context.ShopItems.ToListAsync();
        }

        public async Task<ShopItem> GetShopItemById(Guid shopItemId)
        {
            return await _context.ShopItems.FirstAsync(p => p.ID == shopItemId);
        }

        public async Task<ShopItem> UpdateShopItem(ShopItem toCreate)
        {
            var shopItem = await _context.ShopItems.FirstOrDefaultAsync(p => p.ID == toCreate.ID);
            shopItem.Name = toCreate.Name;
            shopItem.Description = toCreate.Description;
            shopItem.Price = toCreate.Price;
            shopItem.StockQuantity = toCreate.StockQuantity;
            shopItem.Photos = toCreate.Photos;

            await _context.SaveChangesAsync();

            return shopItem;
        }
    }

}
