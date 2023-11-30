using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteComment;
using StrayHome.Application.Features.Commands.DeleteNews;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteNewsCommandHandler(IStrayHomeContext context)
        {
             _context = context;
        }

        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _context.News.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            var hopItem = _context.News
               .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.News.Remove(hopItem);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
