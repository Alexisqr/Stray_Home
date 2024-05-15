using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteComment;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteAllMissingAnimalSelenium
{
    public class DeleteAllMissingAnimalsSeleniumCommandHandler : IRequestHandler<DeleteAllMissingAnimalsSeleniumCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteAllMissingAnimalsSeleniumCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAllMissingAnimalsSeleniumCommand request, CancellationToken cancellationToken)
        {

            var toDelete =  _context.MissingAnimals.Where(p => p.AdType == AdType.Selenium);

            _context.MissingAnimals.RemoveRange(toDelete);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

    }
}
