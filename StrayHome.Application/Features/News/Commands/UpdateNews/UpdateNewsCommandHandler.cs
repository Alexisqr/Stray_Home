using AutoMapper;
using MediatR;
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
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public UpdateNewsCommandHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<News> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var ToUpdate = await _newsRepository.GetNewsById(request.ID);
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

            await _newsRepository.UpdateNews(ToUpdate);


            return ToUpdate;
        }


    }
}
