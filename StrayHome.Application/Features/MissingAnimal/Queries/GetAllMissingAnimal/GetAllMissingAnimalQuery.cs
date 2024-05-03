using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Queries.GetAllMissingAnimal
{
    public class GetAllMissingAnimalQuery : IRequest<IEnumerable<MissingAnimal>>
    {
    }
}
