using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IStrayHomeContext _context;

        public CreateNewsCommandHandler(IStrayHomeContext context)
        {
            _context = context;
        }

        public async Task<News> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var shelterExists = await _context.Shelters.AnyAsync(s => s.ID == request.ShelterID);
            if (!shelterExists)
            {
                throw new Exception($"Shelter with ID {request.ShelterID} not found");
            }
            var news = new News
            {
                Text = request.Text,
                Title = request.Title,
                PublicationDate = request.PublicationDate,
                ShelterID = request.ShelterID,
            };

            _context.News.Add(news);

            await _context.SaveChangesAsync();

            return news;
        }
    }
  
}
