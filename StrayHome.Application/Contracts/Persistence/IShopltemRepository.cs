using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StrayHome.Application;
using StrayHome.Domain.Entities;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IShopltemRepository 
    {
        Task<ICollection<ShopItem>> GetAllShopItem();

        Task<ShopItem> GetShopItemById(Guid shopItemId);

        Task<ShopItem> CreateShopItem(ShopItem toCreate);

        Task<ShopItem> UpdateShopItem(ShopItem toUpdate);

        Task DeleteShopItem(Guid shopItemId);

    }
}
