using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateAnimal;
using StrayHome.Application.Features.Commands.CreateUserShopItem;
using StrayHome.Application.Features.Commands.DeleteAnimal;
using StrayHome.Application.Features.Commands.DeleteUserShopItem;
using StrayHome.Application.Features.Commands.UpdateUserShopItem;
using StrayHome.Application.Features.Queries.GetAllUserShopItem;
using StrayHome.Application.Features.Queries.GetByIdUserShopItem;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserShopItemController : ControllerBase
    {

        private readonly IMediator _mediator;

    public UserShopItemController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet(Name = "GetAllUserShopItem")]
    public async Task<ActionResult<IEnumerable<UserShopItem>>> GetAllUserShopItem()
    {
        var command = new GetAllUserShopItemQuery();
        var userShopItem = await _mediator.Send(command);
        return Ok(userShopItem);
    }
    [HttpGet("{id}", Name = "GetByIdUserShopItem")]
    public async Task<ActionResult<UserShopItem>> GetUserShopItemById(Guid id)
    {
        var command = new GetByIdUserShopItemQuery() { ID = id };
        var userShopItem = await _mediator.Send(command);
        return Ok(userShopItem);
    }
    [HttpDelete("{id}", Name = "DeleteUserShopItem")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteUserShopItem(Guid id)
    {
        var command = new DeleteUserShopItemCommand() { ID = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPut(Name = "UpdateUserShopItem")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateUserShopItem([FromBody] UpdateUserShopItemCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    // testing purpose
    [HttpPost(Name = "CreateUserShopItem")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateUserShopItem([FromBody] CreateUserShopItemCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
}
