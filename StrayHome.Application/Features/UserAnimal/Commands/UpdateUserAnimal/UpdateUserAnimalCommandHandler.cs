using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateUserAnimalCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserAnimal> Handle(UpdateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await  _context.UserAnimals.FirstAsync(p => p.AnimalID == request.AnimalID);

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

            var userAnimal = await _context.UserAnimals.FirstOrDefaultAsync(p => p.AnimalID == toUpdate.AnimalID);
            userAnimal.UserID = toUpdate.UserID;
            userAnimal.AnimalID = toUpdate.AnimalID;
            userAnimal.SubmissionDate = toUpdate.SubmissionDate;
            await _context.SaveChangesAsync();

            return userAnimal;

            return toUpdate;
        }
    }
}
