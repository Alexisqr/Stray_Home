using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
