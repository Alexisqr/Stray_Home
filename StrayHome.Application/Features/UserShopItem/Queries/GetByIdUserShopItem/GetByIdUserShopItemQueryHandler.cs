using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdUserShopItem
{
    public class GetByIdUserShopItemQueryHandler : IRequestHandler<GetByIdUserShopItemQuery, UserShopItem>
    {
        private readonly IUserShopItemRepository _userShopItemRepository;

        public GetByIdUserShopItemQueryHandler(IUserShopItemRepository userShopItemRepository)
        {
            _userShopItemRepository = userShopItemRepository;
        }

        public async Task<UserShopItem> Handle(GetByIdUserShopItemQuery request, CancellationToken cancellationToken)
        {
            return await _userShopItemRepository.GetUserShopItemById(request.ID);
        }


    }
}

