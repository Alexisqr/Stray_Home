using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest<News>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public Guid ShelterID { get; set; }
    }
}
