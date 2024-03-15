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
        private IMemoryCache _cache;

        public ShopItemControllers(IMediator mediator, IMemoryCache cache)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _cache = cache;
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
            var cacheKey = $"ShopItem_{id}";
            var command = new GetByIdShopItemQuery() { ID = id };

            if (!_cache.TryGetValue(cacheKey, out ShopItem shopItem))
            {
                shopItem = await _mediator.Send(command);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set(cacheKey, shopItem, cacheEntryOptions);
            }
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
