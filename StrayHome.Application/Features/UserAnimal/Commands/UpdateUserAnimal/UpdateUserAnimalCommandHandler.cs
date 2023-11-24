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

namespace StrayHome.Application.Features.Commands.UpdateUserAnimal
{
    public class UpdateUserAnimalCommandHandler : IRequestHandler<UpdateUserAnimalCommand, UserAnimal>
    {
        private readonly IUserAnimalRepository _userAnimalRepository;
        private readonly IMapper _mapper;

        public UpdateUserAnimalCommandHandler(IUserAnimalRepository userAnimalRepository, IMapper mapper)
        {
            _userAnimalRepository = userAnimalRepository;
            _mapper = mapper;
        }

        public async Task<UserAnimal> Handle(UpdateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _userAnimalRepository.GetUserAnimalById(request.AnimalID);
            if (toUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateUserAnimalCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(UserAnimal).GetProperty(property.Name);
                    destinationProperty?.SetValue(toUpdate, sourceValue);
                }
            }

            await _userAnimalRepository.UpdateUserAnimal(toUpdate);


            return toUpdate;
        }
    }

}
