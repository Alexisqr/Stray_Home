using MediatR;
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
        private readonly IUserAnimalRepository _userAnimalRepository;

        public CreateUserAnimalCommandHandler(IUserAnimalRepository userAnimalRepository)
        {
            _userAnimalRepository = userAnimalRepository;
        }

        public async Task<UserAnimal> Handle(CreateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            var userAnimal = new UserAnimal
            {
                UserID = request.UserID,
                AnimalID = request.AnimalID,
                SubmissionDate = request.SubmissionDate,
            };

            return await _userAnimalRepository.CreateUserAnimal(userAnimal);
        }
    }
}
