using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetAllAnimal;
using StrayHome.Application.Features.Queries.GetAllComment;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, IEnumerable<Comment>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetAllCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAllComment();
        }
    }
}

