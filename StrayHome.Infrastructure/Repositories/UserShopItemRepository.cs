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
    public class UserShopItemRepository : IUserShopItemRepository
    {
        private readonly StrayHomeContext _context;

        public UserShopItemRepository(StrayHomeContext context)
        {
            _context = context;
        }

        public async Task<UserShopItem> CreateUserShopItem(UserShopItem toCreate)
        {
            _context.UserShopItems.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteUserShopItem(Guid userShopItemId)
        {
            var hopItem = _context.UserShopItems
                .FirstOrDefault(p => p.ID == userShopItemId);

            if (hopItem is null) return;

            _context.UserShopItems.Remove(hopItem);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserShopItem>> GetAllUserShopItem()
        {
            return await _context.UserShopItems.ToListAsync();
        }

        public async Task<UserShopItem> GetUserShopItemById(Guid userShopItemId)
        {
            return await _context.UserShopItems.FirstAsync(p => p.ID == userShopItemId);
        }

        public async Task<UserShopItem> UpdateUserShopItem(UserShopItem toCreate)
        {
            var userShopItem = await _context.UserShopItems.FirstOrDefaultAsync(p => p.ID == toCreate.ID);
            userShopItem.UserID = toCreate.UserID;
            userShopItem.ShopItemID = toCreate.ShopItemID;
            userShopItem.OrderDate = toCreate.OrderDate;
            await _context.SaveChangesAsync();

            return userShopItem;
        }
    }
}
        