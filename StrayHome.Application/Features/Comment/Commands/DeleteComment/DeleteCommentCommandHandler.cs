using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteAnimal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteCommentCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _context.Comments.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            var hopItem = _context.Comments
               .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.Comments.Remove(hopItem);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

