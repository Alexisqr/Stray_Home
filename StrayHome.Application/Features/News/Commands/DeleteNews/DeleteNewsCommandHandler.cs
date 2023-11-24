using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.DeleteComment;
using StrayHome.Application.Features.Commands.DeleteNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
    {

        private readonly INewsRepository _newsRepository;

        public DeleteNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {

            var toDelete = await _newsRepository.GetNewsById(request.ID);

            if (toDelete == null)
            {
                throw new Exception();
            }

            await _newsRepository.DeleteNews(toDelete.ID);

            return Unit.Value;
        }
    }
}
