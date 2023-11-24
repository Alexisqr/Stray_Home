using MediatR;
using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Features.Commands.CreateUserAnimal
{
    public class CreateUserAnimalCommand : IRequest<UserAnimal>
    {
        public Guid UserID { get; set; }
        public Guid AnimalID { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
