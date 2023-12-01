using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateShopItem
{
    public class CreateShopItemCommandHandler : IRequestHandler<CreateShopItemCommand, ShopItem>
    {
        private readonly IStrayHomeContext _context;

        public CreateShopItemCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<ShopItem> Handle(CreateShopItemCommand request, CancellationToken cancellationToken)
        {
            var shopItem = new ShopItem
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Photos = request.Photos,
                StockQuantity = request.StockQuantity,
               
            };
          
            _context.ShopItems.Add(shopItem);

            await _context.SaveChangesAsync();

            return shopItem;
        }
    }
}
