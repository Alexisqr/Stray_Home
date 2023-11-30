using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.UpdateShopItem;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, News>
    {
        private readonly IStrayHomeContext _context;
        private readonly IMapper _mapper;

        public UpdateNewsCommandHandler(IStrayHomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<News> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _context.News.FirstAsync(p => p.ID == request.ID);

            if (ToUpdate == null)
            {
                throw new Exception();
            }

            var propertiesToUpdate = typeof(UpdateNewsCommand).GetProperties();

            foreach (var property in propertiesToUpdate)
            {
                var sourceValue = property.GetValue(request);
                if (sourceValue != null)
                {
                    var destinationProperty = typeof(News).GetProperty(property.Name);
                    destinationProperty?.SetValue(ToUpdate, sourceValue);
                }
            }

            var news = await _context.News.FirstOrDefaultAsync(p => p.ID == ToUpdate.ID);
            news.Text = ToUpdate.Text;
            news.Title = ToUpdate.Title;
            news.PublicationDate = ToUpdate.PublicationDate;
            news.ShelterID = ToUpdate.ShelterID;
            await _context.SaveChangesAsync();

            return news;

        }
    }
}
