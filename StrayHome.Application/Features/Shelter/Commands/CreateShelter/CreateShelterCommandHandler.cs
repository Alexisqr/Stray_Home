using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateShelter
{
    public class CreateShelterCommandHandler : IRequestHandler<CreateShelterCommand, Shelter>
    {
        private readonly IShelterRepository _shelterRepository;

        public CreateShelterCommandHandler(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public async Task<Shelter> Handle(CreateShelterCommand request, CancellationToken cancellationToken)
        {
            var shelter = new Shelter
            {
                Name = request.Name,
                Address = request.Address,
                ContactInfo = request.ContactInfo,
                AdministratorID = request.AdministratorID,

            };

            return await _shelterRepository.CreateShelter(shelter);
        }
    }
}
