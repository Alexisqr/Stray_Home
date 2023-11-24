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

namespace StrayHome.Application.Features.Commands.UpdateShelter
{
    public class UpdateShelterCommandHandler : IRequestHandler<UpdateShelterCommand, Shelter>
    {
        private readonly IShelterRepository _shelterRepository;
        private readonly IMapper _mapper;

        public UpdateShelterCommandHandler(IShelterRepository shelterRepository, IMapper mapper)
        {
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }

        public async Task<Shelter> Handle(UpdateShelterCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _shelterRepository.GetShelterById(request.ID);
            if (ToUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateShelterCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(Shelter).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }

            await _shelterRepository.UpdateShelter(ToUpdate);


            return ToUpdate;
        }


    }
}

