using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateShelterAdmin;
using StrayHome.Application.Features.Commands.CreateUserShopItem;
using StrayHome.Application.Features.Commands.DeleteShelterAdmin;
using StrayHome.Application.Features.Commands.DeleteUserShopItem;
using StrayHome.Application.Features.Commands.UpdateShelterAdmin;
using StrayHome.Application.Features.Commands.UpdateUserShopItem;
using StrayHome.Application.Features.Queries.GetAllShelterAdmin;
using StrayHome.Application.Features.Queries.GetAllUserShopItem;
using StrayHome.Application.Features.Queries.GetByIdShelterAdmin;
using StrayHome.Application.Features.Queries.GetByIdUserShopItem;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShelterAdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelterAdminController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetAllShelterAdmin")]
        public async Task<ActionResult<IEnumerable<ShelterAdmin>>> GetAllShelterAdmin()
        {
            var command = new GetAllShelterAdminQuery();
            var shelterAdmin = await _mediator.Send(command);
            return Ok(shelterAdmin);
        }
        [HttpGet("{id}", Name = "GetByIdShelterAdmin")]
        public async Task<ActionResult<ShelterAdmin>> GetShelterAdminById(Guid id)
        {
            var command = new GetByIdShelterAdminQuery() { ID = id };
            var shelterAdmin = await _mediator.Send(command);
            return Ok(shelterAdmin);
        }
        [HttpDelete("{id}", Name = "DeleteShelterAdmin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteShelterAdmin(Guid id)
        {
            var command = new DeleteShelterAdminCommand() { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name = "UpdateShelterAdmin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateShelterAdmin([FromBody] UpdateShelterAdminCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost(Name = "CreateShelterAdmin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateShelterAdmin([FromBody] CreateShelterAdminCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
