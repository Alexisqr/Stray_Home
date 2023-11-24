using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllShopItem
{
    public class GetAllShopItemQuery : IRequest<IEnumerable<ShopItem>>
    {
        // No additional properties needed for this example
    }
}
