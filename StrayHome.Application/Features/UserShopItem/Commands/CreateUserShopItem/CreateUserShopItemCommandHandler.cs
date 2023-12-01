using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IStrayHomeContext _context;

        public CreateUserShopItemCommandHandler(IStrayHomeContext context)
        {
            _context = context; ;
        }

        public async Task<UserShopItem> Handle(CreateUserShopItemCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _context.Users.AnyAsync(s => s.ID == request.UserID);
            if (!userExists)
            {
                throw new Exception($"User with ID {request.UserID} not found");
            }

            var shopItemsExists = await _context.ShopItems.AnyAsync(s => s.ID == request.ShopItemID);
            if (!shopItemsExists)
            {
                throw new Exception($"ShopItem with ID {request.ShopItemID} not found");
            }
            var userShopItem = new UserShopItem
            {
                UserID = request.UserID,
                ShopItemID = request.ShopItemID,
                OrderDate = request.OrderDate,
            };

            _context.UserShopItems.Add(userShopItem);

            await _context.SaveChangesAsync();

            return userShopItem;
        }
    }
}
