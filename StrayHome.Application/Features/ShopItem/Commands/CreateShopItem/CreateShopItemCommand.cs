using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateShopItem
{
    public class CreateShopItemCommand : IRequest<ShopItem>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Photos { get; set; }
        public int StockQuantity { get; set; }

    }
}
