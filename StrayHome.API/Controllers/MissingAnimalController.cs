using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateMissingAnimal;
using StrayHome.Application.Features.Commands.CreateMissingAnimalsSelenium;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MissingAnimalController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MissingAnimalController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
       
        // testing purpose
        [HttpPost(Name = "CreateMissingAnimal")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMissingAnimal([FromBody] CreateMissingAnimalCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("CreateMissingAnimalSelenium",Name = "CreateMissingAnimalSelenium")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMissingAnimalsSelenium([FromBody] CreateMissingAnimalsSeleniumCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
