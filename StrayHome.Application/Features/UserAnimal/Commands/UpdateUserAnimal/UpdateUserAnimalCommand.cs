using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.UpdateUserAnimal
{
    public class UpdateUserAnimalCommand : IRequest<UserAnimal>
    {
    public Guid AnimalID { get; set; }
    }
}
