using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Application.Features.Commands.CreateUser;
using System.Net;

namespace StrayHome.API.Controllers
{
   // [Authorize]
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

    }
}
