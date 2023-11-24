using AutoMapper;
using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateAnimal;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _commentRepository.GetCommentById(request.ID);
            if (ToUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateCommentCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(Comment).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }

            await _commentRepository.UpdateComment(ToUpdate);


            return ToUpdate;
        }


    }
}

