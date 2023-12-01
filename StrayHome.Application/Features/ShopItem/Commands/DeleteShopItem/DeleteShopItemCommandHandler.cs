using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

        private readonly IStrayHomeContext _context;

        public DeleteShopItemCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }
       
        public async Task<Unit> Handle(DeleteShopItemCommand request, CancellationToken cancellationToken) 
        { 

            var toDelete = await _context.ShopItems.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            var shopItemUser = _context.UserShopItems.Where(a => a.ShopItemID == request.ID);
            _context.UserShopItems.RemoveRange(shopItemUser);

            var hopItem = _context.ShopItems
                .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.ShopItems.Remove(hopItem);

            await _context.SaveChangesAsync();
            return Unit.Value;
        }

    }
}
