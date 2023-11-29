using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IStrayHomeContext _context;
        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IStrayHomeContext context)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            byte[] salt;
            var password = _passwordHasher.Hash(request.Password,out salt);
            var user = new User
            {
                Username = request.Username,
                Password = password,
                Salt = Convert.ToBase64String(salt),
                Role = UserRole.User,
                Email = request.Email,
                CreationDate = DateTime.UtcNow,
            };

            return await _userRepository.CreateUser(user);
        }
    }
}
