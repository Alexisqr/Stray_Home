using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateUserAnimal
{
    public class CreateUserAnimalCommandHandler : IRequestHandler<CreateUserAnimalCommand, UserAnimal>
    {
        private readonly IStrayHomeContext _context;

        public CreateUserAnimalCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<UserAnimal> Handle(CreateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _context.Users.AnyAsync(s => s.ID == request.UserID);
            if (!userExists)
            {
                throw new Exception($"User with ID {request.UserID} not found");
            }

            var animalExists = await _context.Animals.AnyAsync(s => s.ID == request.AnimalID);
            if (!animalExists)
            {
                throw new Exception($"Animal with ID {request.AnimalID} not found");
            }

            var userAnimal = new UserAnimal
            {
                UserID = request.UserID,
                AnimalID = request.AnimalID,
                SubmissionDate = request.SubmissionDate,
            };

            _context.UserAnimals.Add(userAnimal);

            await _context.SaveChangesAsync();

            return userAnimal;
        }
    }
}
