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

namespace StrayHome.Application.Features.Queries.GetByIdNews
{
    public class GetByIdNewsQueryHandler : IRequestHandler<GetByIdNewsQuery, News>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdNewsQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<News> Handle(GetByIdNewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.News.FirstAsync(p => p.ID == request.ID);
        }


    }
   
}
