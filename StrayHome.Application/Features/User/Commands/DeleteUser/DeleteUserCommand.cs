using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Featuresb .Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
