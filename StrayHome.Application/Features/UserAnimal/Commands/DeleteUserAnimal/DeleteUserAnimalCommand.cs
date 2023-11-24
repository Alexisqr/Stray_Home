using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.DeleteUserAnimal
{
    public class DeleteUserAnimalCommand : IRequest
    {
        public Guid AnimalID { get; set; }
     }
}
