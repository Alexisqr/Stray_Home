using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StrayHome.Application.Features.Commands.CreateMissingAnimalsSelenium;
using StrayHome.Application.Features.Commands.DeleteAllMissingAnimalSelenium;

namespace StrayHome.Infrastructure.Jobs
{
    public class UpdateListOfMissingAnimals : IJob
    {
        private readonly IMediator _mediator;

        public UpdateListOfMissingAnimals(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var commandDelete = new DeleteAllMissingAnimalsSeleniumCommand();
            await _mediator.Send(commandDelete);
            var commandCreate = new CreateMissingAnimalsSeleniumCommand();
            await _mediator.Send(commandCreate);
            

        }
    }
}
