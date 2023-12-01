﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateShopItem
{
    public class UpdateShopItemCommandHandler : IRequestHandler<UpdateShopItemCommand, ShopItem>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateShopItemCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ;
        }

        public async Task<ShopItem> Handle(UpdateShopItemCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _context.ShopItems.FirstAsync(p => p.ID == request.ID);

            if (ToUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateShopItemCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(ShopItem).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }

            var shopItem = await _context.ShopItems.FirstOrDefaultAsync(p => p.ID == ToUpdate.ID);
            shopItem.Name = ToUpdate.Name;
            shopItem.Description = ToUpdate.Description;
            shopItem.Price = ToUpdate.Price;
            shopItem.StockQuantity = ToUpdate.StockQuantity;
            shopItem.Photos = ToUpdate.Photos;

            await _context.SaveChangesAsync();

            return shopItem;
        }
    }
}

