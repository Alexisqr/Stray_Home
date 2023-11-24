using AutoMapper;
using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteShopItem
{
    public class DeleteShopItemCommandHandler : IRequestHandler<DeleteShopItemCommand>
    {

        private readonly IShopltemRepository _shopItemRepository;

        public DeleteShopItemCommandHandler(IShopltemRepository shopItemRepository)
        {
            _shopItemRepository = shopItemRepository;
        }
       
        public async Task<Unit> Handle(DeleteShopItemCommand request, CancellationToken cancellationToken) 
        { 

            var toDelete = await _shopItemRepository.GetShopItemById(request.ID);

            if (toDelete == null)
            {
            throw new Exception();
            }

            await _shopItemRepository.DeleteShopItem(toDelete.ID);

            return Unit.Value;
        }

    }
}
