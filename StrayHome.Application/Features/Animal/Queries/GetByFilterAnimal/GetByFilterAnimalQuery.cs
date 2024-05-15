using MediatR;
using StrayHome.Domain.Entities;
using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetByFilterAnimal
{
    public class GetByFilterAnimalQuery : IRequest<IEnumerable<Animal>>
    {
        public string? Location { get; set; }
        public string? TypeAnimal { get; set; }
        public string? Sex { get; set; }
        public double? Age { get; set; }
        public bool? Sterilization { get; set; }
        public string? Shelter { get; set; }
    }
}
