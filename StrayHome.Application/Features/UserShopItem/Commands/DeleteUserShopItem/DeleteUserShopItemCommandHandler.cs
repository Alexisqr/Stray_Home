using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Featuresb.Commands.DeleteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteUserShopItem
{
    public class DeleteUserShopItemCommandHandler : IRequestHandler<DeleteUserShopItemCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteUserShopItemCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserShopItemCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _context.UserShopItems.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            var hopItem = _context.UserShopItems
             .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.UserShopItems.Remove(hopItem);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

    }
}
