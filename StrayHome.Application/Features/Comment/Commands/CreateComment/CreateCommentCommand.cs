using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Comment>
    {
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserID { get; set; }
        public Guid ShelterID { get; set; }

    }
}
