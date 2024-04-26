using MediatR;
using Microsoft.AspNetCore.Http;
using StrayHome.Domain.DTO;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.AddListOfAnimals
{
    public class AddListOfAnimalsCommand : IRequest<IEnumerable<Animal>>
    {
       public Guid ID { get; set; }
       public IFormFile File { get; set; }

    }
}
