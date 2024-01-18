using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Application.Features.Commands.DeleteShopItem;
using StrayHome.Application.Features.Commands.UpdateShopItem;
using StrayHome.Application.Features.Queries.GetAllShopItem;
using StrayHome.Application.Features.Queries.GetShopItemById;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShopItemControllers : ControllerBase
    {

        private readonly IMediator _mediator;
  
        public ShopItemControllers(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet(Name = "GetAllShopItem")]
        public async Task<ActionResult<IEnumerable<ShopItem>>> GetAllShopItem()
        {
            var command = new GetAllShopItemQuery();
            var shopItems = await _mediator.Send(command);
            return Ok(shopItems);
        }
        [HttpGet("{id}", Name = "GetByIdShopItem")]
        public async Task<ActionResult<ShopItem>> GetShopItemById(Guid id)
        {
            var command = new GetByIdShopItemQuery() { ID = id };
            var shopItem = await _mediator.Send(command);
            return Ok(shopItem);
        }
        [HttpDelete("{id}", Name = "DeleteShopItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteShopItem(Guid id)
        {
            var command = new DeleteShopItemCommand() { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name = "UpdateShopItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateShopItem([FromBody] UpdateShopItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // testing purpose
        [Authorize(Policy = "Admin")]
        [HttpPost(Name = "CreateShopItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateShopItem([FromBody] CreateShopItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
