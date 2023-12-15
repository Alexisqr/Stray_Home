using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Application.Features.Commands.CreateUser;
using StrayHome.Application.Features.Commands.CreateUserAnimal;
using StrayHome.Application.Features.Commands.DeleteUserAnimal;
using StrayHome.Application.Features.Commands.UpdateUser;
using StrayHome.Application.Features.Commands.UpdateUserAnimal;
using StrayHome.Application.Features.Queries.GetAllUser;
using StrayHome.Application.Features.Queries.GetAllUserAnimal;
using StrayHome.Application.Features.Queries.GetByIdUser;
using StrayHome.Application.Features.Queries.GetByIdUserAnimal;
using StrayHome.Application.Featuresb.Commands.DeleteUser;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{
   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
      
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // POST 
        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateShopItem([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // GET
        [Authorize]
        [HttpGet(Name = "GetAllUser")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var command = new GetAllUserQuery();
            var user = await _mediator.Send(command);
            return Ok(user);
        }
       
        [HttpGet("{id}", Name = "GetByIdUser")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var command = new GetByIdUserQuery() { ID = id };
            var user = await _mediator.Send(command);
            return Ok(user);
        }
        // PUT 
        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand() { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
