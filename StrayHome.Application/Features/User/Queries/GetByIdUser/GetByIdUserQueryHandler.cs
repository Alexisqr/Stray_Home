using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetShopItemById;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, User>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdUserQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstAsync(p => p.ID == request.ID);
        }


    }
   
}
