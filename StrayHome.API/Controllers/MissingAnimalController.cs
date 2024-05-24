using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateMissingAnimal;
using StrayHome.Application.Features.Commands.CreateMissingAnimalsSelenium;
using StrayHome.Application.Features.Commands.DeleteComment;
using StrayHome.Application.Features.Commands.DeleteMissingAnimal;
using StrayHome.Application.Features.Commands.UpdateComment;
using StrayHome.Application.Features.Commands.UpdateMissingAnimal;
using StrayHome.Application.Features.Queries.GetAllComment;
using StrayHome.Application.Features.Queries.GetAllMissingAnimal;
using StrayHome.Application.Features.Queries.GetByIdComment;
using StrayHome.Application.Features.Queries.GetByIdMissingAnimal;
using StrayHome.Domain.Entities;
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
        [HttpGet(Name = "GetAllMissingAnimal")]
        public async Task<ActionResult<IEnumerable<MissingAnimal>>> GetAllMissingAnimal()
        {
            var missingAnimal = new GetAllMissingAnimalQuery();
            var missingAnimals = await _mediator.Send(missingAnimal);
            return Ok(missingAnimals);
        }
        [HttpGet("{id}", Name = "GetByIdMissingAnimal")]
        public async Task<ActionResult<MissingAnimal>> GetMissingAnimalById(Guid id)
        {
            var missingAnimal = new GetByIdMissingAnimalQuery() { ID = id };
            var missingAnimals = await _mediator.Send(missingAnimal);
            return Ok(missingAnimals);
        }
        [HttpDelete("{id}", Name = "DeleteMissingAnimal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteMissingAnimal(Guid id)
        {
            var missingAnimal = new DeleteMissingAnimalCommand() { ID = id };
            await _mediator.Send(missingAnimal);
            return NoContent();
        }
        [HttpPut(Name = "UpdateMissingAnimal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateMissingAnimal([FromBody] UpdateMissingAnimalCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // testing purpose
        [HttpPost(Name = "CreateMissingAnimal")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMissingAnimal([FromBody] CreateMissingAnimalCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("CreateMissingAnimalSwagger")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMissingAnimalSwagger([FromBody] CreateMissingAnimalsSeleniumCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
