using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateComment;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateMissingAnimal
{
    public class UpdateMissingAnimalCommandHandler : IRequestHandler<UpdateMissingAnimalCommand, MissingAnimal>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateMissingAnimalCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MissingAnimal> Handle(UpdateMissingAnimalCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _context.MissingAnimals.FirstAsync(p => p.ID == request.ID);
            if (ToUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateMissingAnimalCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(MissingAnimal).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }

            var missingAnimal = await _context.MissingAnimals.FirstOrDefaultAsync(p => p.ID == ToUpdate.ID);
            missingAnimal.Name = ToUpdate.Name;
            missingAnimal.Description = ToUpdate.Description;
            missingAnimal.Location = ToUpdate.Location;
            missingAnimal.ImageLink = ToUpdate.ImageLink;
            await _context.SaveChangesAsync();

            return missingAnimal;
        }
    }
}
