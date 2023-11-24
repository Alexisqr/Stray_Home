using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateAnimal;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateComment
{
    public class CreateCommentCommentHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Text = request.Text,
                CreationDate = request.CreationDate,
                UserID = request.UserID,
                ShelterID = request.ShelterID,
                

            };

            return await _commentRepository.CreateComment(comment);
        }
    }
}

