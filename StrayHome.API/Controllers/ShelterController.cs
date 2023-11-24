using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateAnimal;
using StrayHome.Application.Features.Commands.CreateShelter;
using StrayHome.Application.Features.Commands.DeleteAnimal;
using StrayHome.Application.Features.Commands.DeleteShelter;
using StrayHome.Application.Features.Commands.UpdateAnimal;
using StrayHome.Application.Features.Commands.UpdateShelter;
using StrayHome.Application.Features.Queries.GetAllAnimal;
using StrayHome.Application.Features.Queries.GetAllShelter;
using StrayHome.Application.Features.Queries.GetByIdAnimal;
using StrayHome.Application.Features.Queries.GetByIdShelter;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShelterController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ShelterController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet(Name = "GetAllShelter")]
        public async Task<ActionResult<IEnumerable<Shelter>>> GetAllShelter()
        {
            var command = new GetAllShelterQuery();
            var animals = await _mediator.Send(command);
            return Ok(animals);
        }
        [HttpGet("{id}", Name = "GetByIdShelter")]
        public async Task<ActionResult<Shelter>> GetShelterById(Guid id)
        {
            var command = new GetByIdShelterQuery() { ID = id };
            var animals = await _mediator.Send(command);
            return Ok(animals);
        }
        [HttpDelete("{id}", Name = "DeleteShelter")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteShelter(Guid id)
        {
            var command = new DeleteShelterCommand() { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name = "UpdateShelter")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateShelter([FromBody] UpdateShelterCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // testing purpose
        [HttpPost(Name = "CreateShelter")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateShelter([FromBody] CreateShelterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
