using MediatR;
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
       public IEnumerable<AnimalDto> Animals { get; set; }
       public Guid ID { get; set; }

    }
}
