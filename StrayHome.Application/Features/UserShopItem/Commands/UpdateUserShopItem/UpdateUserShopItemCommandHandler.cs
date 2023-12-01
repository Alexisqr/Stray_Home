using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateUserShopItem
{
    public class UpdateUserShopItemCommandHandler : IRequestHandler<UpdateUserShopItemCommand, UserShopItem>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateUserShopItemCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserShopItem> Handle(UpdateUserShopItemCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _context.UserShopItems.FirstAsync(p => p.ID == request.ID);

            if (toUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateUserShopItemCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(UserShopItem).GetProperty(property.Name);
                    destinationProperty?.SetValue(toUpdate, sourceValue);
                }
            }

            var userShopItem = await _context.UserShopItems.FirstOrDefaultAsync(p => p.ID == toUpdate.ID);
            userShopItem.UserID = toUpdate.UserID;
            userShopItem.ShopItemID = toUpdate.ShopItemID;
            userShopItem.OrderDate = toUpdate.OrderDate;
            await _context.SaveChangesAsync();

            return userShopItem;
        }
    }
}

