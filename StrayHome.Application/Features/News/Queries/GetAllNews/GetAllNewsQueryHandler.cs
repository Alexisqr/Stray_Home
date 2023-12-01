using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllNews
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
    {
        private readonly IStrayHomeContext _context;

        public GetAllNewsQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.News.ToListAsync();
        }
    }
   
}
