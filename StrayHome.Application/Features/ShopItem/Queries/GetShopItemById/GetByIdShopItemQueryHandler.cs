using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetShopItemById
{
    public class GetByIdShopItemQueryHandler : IRequestHandler<GetByIdShopItemQuery, ShopItem>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdShopItemQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<ShopItem> Handle(GetByIdShopItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.ShopItems.FirstAsync(p => p.ID == request.ID);
        }

   
    }
}
