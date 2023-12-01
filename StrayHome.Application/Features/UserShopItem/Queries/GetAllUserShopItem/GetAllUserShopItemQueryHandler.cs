using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllUserShopItem
{
    public class GetAllUserShopItemQueryHandler : IRequestHandler<GetAllUserShopItemQuery, IEnumerable<UserShopItem>>
    {
        private readonly IStrayHomeContext _context;

        public GetAllUserShopItemQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserShopItem>> Handle(GetAllUserShopItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.UserShopItems.ToListAsync();
        }
    }
}
