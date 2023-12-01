using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetShopItemById;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllShopItem
{
    public class GetAllShopItemsQueryHandler : IRequestHandler<GetAllShopItemQuery, IEnumerable<ShopItem>>
    {
        private readonly IStrayHomeContext _context;

        public GetAllShopItemsQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShopItem>> Handle(GetAllShopItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.ShopItems.ToListAsync();
        }
    }


}
