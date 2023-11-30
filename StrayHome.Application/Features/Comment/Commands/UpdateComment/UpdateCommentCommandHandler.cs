using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateAnimal;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _context.Comments.FirstAsync(p => p.ID == request.ID);
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
        
            var comment = await _context.Comments.FirstOrDefaultAsync(p => p.ID == ToUpdate.ID);
            comment.Text = ToUpdate.Text;
            comment.CreationDate = ToUpdate.CreationDate;
            comment.UserID = ToUpdate.UserID;
            comment.ShelterID = ToUpdate.ShelterID;
            await _context.SaveChangesAsync();

            return comment;
        }


    }
}

