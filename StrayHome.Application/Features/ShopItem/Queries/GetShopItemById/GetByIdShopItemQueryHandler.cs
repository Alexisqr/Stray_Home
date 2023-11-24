using MediatR;
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
        private readonly IShopltemRepository _shopItemRepository;

        public GetByIdShopItemQueryHandler(IShopltemRepository shopItemRepository)
        {
            _shopItemRepository = shopItemRepository;
        }

        public async Task<ShopItem> Handle(GetByIdShopItemQuery request, CancellationToken cancellationToken)
        {
            return await _shopItemRepository.GetShopItemById(request.ID);
        }

   
    }
}
