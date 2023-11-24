using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateUserShopItem
{
    public class CreateUserShopItemCommandHandler : IRequestHandler<CreateUserShopItemCommand, UserShopItem>
    {
        private readonly IUserShopItemRepository _userShopItemRepository;

        public CreateUserShopItemCommandHandler(IUserShopItemRepository userShopItemRepository)
        {
            _userShopItemRepository = userShopItemRepository;
        }

        public async Task<UserShopItem> Handle(CreateUserShopItemCommand request, CancellationToken cancellationToken)
        {
            var userShopItem = new UserShopItem
            {
                UserID = request.UserID,
                ShopItemID = request.ShopItemID,
                OrderDate = request.OrderDate,
             


            };

            return await _userShopItemRepository.CreateUserShopItem(userShopItem);
        }
    }
}
