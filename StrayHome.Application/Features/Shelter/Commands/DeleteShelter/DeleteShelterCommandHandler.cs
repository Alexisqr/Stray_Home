using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;


namespace StrayHome.Application.Features.Commands.DeleteShelter
{
    public class DeleteShelterCommandHandler : IRequestHandler<DeleteShelterCommand>
    {

        private readonly IStrayHomeContext _context;

        public DeleteShelterCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteShelterCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _context.Shelters.FirstAsync(p => p.ID == request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            var shelterAnimals = _context.Animals.Where(a => a.ShelterID == request.ID);
            _context.Animals.RemoveRange(shelterAnimals);
            var shelterComment = _context.Comments.Where(a => a.ShelterID == request.ID);
            _context.Comments.RemoveRange(shelterComment);
            var shelterNews = _context.News.Where(a => a.ShelterID == request.ID);
            _context.News.RemoveRange(shelterNews);

            var hopItem = _context.Shelters
                .FirstOrDefault(p => p.ID == toDelete.ID);

            _context.Shelters.Remove(hopItem);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

    }
}

