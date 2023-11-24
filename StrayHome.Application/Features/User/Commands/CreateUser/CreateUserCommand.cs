using MediatR;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
