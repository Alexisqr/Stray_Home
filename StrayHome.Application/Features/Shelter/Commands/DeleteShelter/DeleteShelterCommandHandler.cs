using MediatR;
using StrayHome.Application.Contracts.Persistence;


namespace StrayHome.Application.Features.Commands.DeleteShelter
{
    public class DeleteShelterCommandHandler : IRequestHandler<DeleteShelterCommand>
    {

        private readonly IShelterRepository _shelterRepository;

        public DeleteShelterCommandHandler(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public async Task<Unit> Handle(DeleteShelterCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _shelterRepository.GetShelterById(request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            await _shelterRepository.DeleteShelter(toDelete.ID);

            return Unit.Value;
        }

    }
}

