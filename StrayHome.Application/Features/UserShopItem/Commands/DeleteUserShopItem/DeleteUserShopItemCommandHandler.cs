using MediatR;
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

            var toDelete = await _userShopItemRepository.GetUserShopItemById(request.ID);

            if (toDelete == null)
            {
                 throw new Exception();
            }

            await _userShopItemRepository.DeleteUserShopItem(toDelete.ID);

            return Unit.Value;
        }

    }
}
