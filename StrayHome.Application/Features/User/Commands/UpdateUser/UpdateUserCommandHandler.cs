using AutoMapper;
using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository shopItemRepository, IMapper mapper)
        {
            _userRepository = shopItemRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _userRepository.GetUserById(request.ID);
            if (toUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateUserCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(User).GetProperty(property.Name);
                    destinationProperty?.SetValue(toUpdate, sourceValue);
                }
            }

            await _userRepository.UpdateUser(toUpdate);


            return toUpdate;
        }
    }
}
