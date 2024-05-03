using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.AddListOfAnimals;
using StrayHome.Application.Features.Commands.CreateMissingAnimalsSelenium;
using StrayHome.Domain.DTO;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateMissingAnimalsSelenium
{
    public class CreateMissingAnimalsSeleniumCommandHandler : IRequestHandler<CreateMissingAnimalsSeleniumCommand, IEnumerable<MissingAnimal>>
    {
        private readonly IStrayHomeContext _context;
        private readonly ISeleniumService _seleniumService;
        public CreateMissingAnimalsSeleniumCommandHandler(IStrayHomeContext context, ISeleniumService seleniumService)
        {
            _context = context;
            _seleniumService = seleniumService;
        }

        public async Task<IEnumerable<MissingAnimal>> Handle(CreateMissingAnimalsSeleniumCommand request, CancellationToken cancellationToken)
        {
            var data = _seleniumService.DataSearch();

            var resultAnimals = new List<MissingAnimal>();

            foreach (var animal in await data)
            {
                var animalCreate = new MissingAnimal
                {
                    Name = animal.Name,
                    Description = animal.Description,
                    ImageLink = animal.ImageLink,
                    Location = animal.Location,
                    Link = animal.Link,
                    AdType = AdType.Selenium,

                };

                _context.MissingAnimals.Add(animalCreate);
                resultAnimals.Add(animalCreate);
            }

            await _context.SaveChangesAsync();
            return resultAnimals;
        }
    }
}
