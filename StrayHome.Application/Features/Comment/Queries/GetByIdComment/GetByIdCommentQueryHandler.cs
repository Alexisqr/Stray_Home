using MediatR;
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
        private readonly ICommentRepository _commentRepository;

        public GetByIdCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetCommentById(request.ID);
        }

    }
}
