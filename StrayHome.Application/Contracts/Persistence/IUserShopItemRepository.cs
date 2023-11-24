using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IUserShopItemRepository
    {
        Task<ICollection<UserShopItem>> GetAllUserShopItem();

        Task<UserShopItem> GetUserShopItemById(Guid userShopItemId);

        Task<UserShopItem> CreateUserShopItem(UserShopItem toCreate);

        Task<UserShopItem> UpdateUserShopItem(UserShopItem toUpdate);

        Task DeleteUserShopItem(Guid userShopItemId);
    }
}
