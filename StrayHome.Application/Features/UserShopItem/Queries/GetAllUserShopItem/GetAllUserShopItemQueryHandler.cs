using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllUserShopItem
{
    public class GetAllUserShopItemQueryHandler : IRequestHandler<GetAllUserShopItemQuery, IEnumerable<UserShopItem>>
    {
        private readonly IUserShopItemRepository _userShopItemRepository;

        public GetAllUserShopItemQueryHandler(IUserShopItemRepository userShopItemRepository)
        {
            _userShopItemRepository = userShopItemRepository;
        }

        public async Task<IEnumerable<UserShopItem>> Handle(GetAllUserShopItemQuery request, CancellationToken cancellationToken)
        {
            return await _userShopItemRepository.GetAllUserShopItem();
        }
    }
}
