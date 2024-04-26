using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateComment;
using StrayHome.Application.Features.Commands.CreateMissingAnimal;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateMissingAnimal
{
    public class CreateMissingAnimalCommandHandler : IRequestHandler<CreateMissingAnimalCommand, MissingAnimal>
    {
        private readonly IStrayHomeContext _context;
        public CreateMissingAnimalCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<MissingAnimal> Handle(CreateMissingAnimalCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _context.Users.AnyAsync(u => u.ID == request.UserID);
            if (!userExists)
            {
                throw new Exception($"User with ID {request.UserID} not found");
            }

            var createMissingAnimalCommand = new MissingAnimal
            {
                Name = request.Name,
                Description = request.Description,
                UserID = request.UserID,
                ImageLink = request.ImageLink,
                Location = request.Location,
                AdType = AdType.User
            };

            _context.MissingAnimals.Add(createMissingAnimalCommand);

            await _context.SaveChangesAsync();

            return createMissingAnimalCommand;
        }
    }
}
