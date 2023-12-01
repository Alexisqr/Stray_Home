using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdUserShopItem
{
    public class GetByIdUserShopItemQueryHandler : IRequestHandler<GetByIdUserShopItemQuery, UserShopItem>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdUserShopItemQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<UserShopItem> Handle(GetByIdUserShopItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.UserShopItems.FirstAsync(p => p.ID == request.ID);
        }
    }
}

