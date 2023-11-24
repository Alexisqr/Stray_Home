using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateUserAnimal;
using StrayHome.Application.Features.Commands.DeleteUserAnimal;
using StrayHome.Application.Features.Commands.UpdateUserAnimal;
using StrayHome.Application.Features.Queries.GetAllUserAnimal;
using StrayHome.Application.Features.Queries.GetByIdUserAnimal;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserAnimalController :  ControllerBase
    {

        private readonly IMediator _mediator;

    public UserAnimalController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet(Name = "GetAllUserAnimal")]
    public async Task<ActionResult<IEnumerable<UserAnimal>>> GetAllUserAnimal()
    {
        var command = new GetAllUserAnimalQuery();
        var userAnimal = await _mediator.Send(command);
        return Ok(userAnimal);
    }
    [HttpGet("{id}", Name = "GetByIdUserAnimal")]
    public async Task<ActionResult<UserAnimal>> GetUserAnimalById(Guid id)
    {
        var command = new GetByIdUserAnimalQuery() { AnimalID = id };
        var userAnimal = await _mediator.Send(command);
        return Ok(userAnimal);
    }
    [HttpDelete("{id}", Name = "DeleteUserAnimal")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteUserAnimal(Guid id)
    {
        var command = new DeleteUserAnimalCommand() { AnimalID = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPut(Name = "UpdateUserAnimal")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateUserAnimal([FromBody] UpdateUserAnimalCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    // testing purpose
    [HttpPost(Name = "CreateUserAnimal")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateUserAnimal([FromBody] CreateUserAnimalCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    }
}
