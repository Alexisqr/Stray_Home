using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdComment;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllComment
{
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, Comment>
    {
        private readonly IStrayHomeContext _context;

        public GetByIdCommentQueryHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Comment> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comments.FirstAsync(p => p.ID == request.ID);
        }

    }
}
