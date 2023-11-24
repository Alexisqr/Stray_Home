using MediatR;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateComment;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, News>
    {
        private readonly INewsRepository _newsRepository;

        public CreateNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new News
            {
                Text = request.Text,
                Title = request.Title,
                PublicationDate = request.PublicationDate,
                ShelterID = request.ShelterID,


            };

            return await _newsRepository.CreateNews(news);
        }
    }
  
}
