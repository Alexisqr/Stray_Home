using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Queries.GetByIdUser;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByIdUserAnimal
{
    public class GetByIdUserAnimalQueryHandler : IRequestHandler<GetByIdUserAnimalQuery, UserAnimal>
    {
        private readonly IUserAnimalRepository _userAnimalRepository;

        public GetByIdUserAnimalQueryHandler(IUserAnimalRepository userAnimalRepository)
        {
            _userAnimalRepository = userAnimalRepository;
        }

        public async Task<UserAnimal> Handle(GetByIdUserAnimalQuery request, CancellationToken cancellationToken)
        {
            return await _userAnimalRepository.GetUserAnimalById(request.AnimalID);
        }


    }
}

