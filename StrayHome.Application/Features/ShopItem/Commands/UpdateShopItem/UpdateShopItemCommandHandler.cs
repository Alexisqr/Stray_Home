using AutoMapper;
using MediatR;
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
        private readonly IShopltemRepository _shopItemRepository;
        private readonly IMapper _mapper;

        public UpdateShopItemCommandHandler(IShopltemRepository shopItemRepository, IMapper mapper)
        {
            _shopItemRepository = shopItemRepository;
            _mapper = mapper ;
        }

        public async Task<ShopItem> Handle(UpdateShopItemCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _shopItemRepository.GetShopItemById(request.ID);
            if (orderToUpdate == null)
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
                    destinationProperty?.SetValue(orderToUpdate, sourceValue);
                }
            }

            await _shopItemRepository.UpdateShopItem(orderToUpdate);
          

            return orderToUpdate;
        }

     
    }
}

