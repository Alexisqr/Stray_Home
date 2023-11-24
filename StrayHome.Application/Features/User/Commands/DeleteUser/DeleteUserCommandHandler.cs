using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Featuresb.Commands.DeleteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {

        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _userRepository.GetUserById(request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            await _userRepository.DeleteUser(toDelete.ID);

            return Unit.Value;
        }

    }
}

