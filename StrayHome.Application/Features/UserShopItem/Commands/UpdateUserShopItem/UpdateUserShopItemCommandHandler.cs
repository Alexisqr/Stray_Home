using AutoMapper;
using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateUserShopItem
{
    public class UpdateUserShopItemCommandHandler : IRequestHandler<UpdateUserShopItemCommand, UserShopItem>
    {
        private readonly IUserShopItemRepository _userShopItemRepository;
        private readonly IMapper _mapper;

        public UpdateUserShopItemCommandHandler(IUserShopItemRepository userShopItemRepository, IMapper mapper)
        {
            _userShopItemRepository = userShopItemRepository;
            _mapper = mapper;
        }

        public async Task<UserShopItem> Handle(UpdateUserShopItemCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _userShopItemRepository.GetUserShopItemById(request.ID);
            if (toUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateUserShopItemCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(UserShopItem).GetProperty(property.Name);
                    destinationProperty?.SetValue(toUpdate, sourceValue);
                }
            }

            await _userShopItemRepository.UpdateUserShopItem(toUpdate);


            return toUpdate;
        }
    }
}

