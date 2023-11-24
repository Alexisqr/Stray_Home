using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateAnimal;
using StrayHome.Application.Features.Commands.CreateNews;
using StrayHome.Application.Features.Commands.DeleteAnimal;
using StrayHome.Application.Features.Commands.DeleteNews;
using StrayHome.Application.Features.Commands.UpdateAnimal;
using StrayHome.Application.Features.Commands.UpdateNews;
using StrayHome.Application.Features.Queries.GetAllAnimal;
using StrayHome.Application.Features.Queries.GetAllNews;
using StrayHome.Application.Features.Queries.GetByIdAnimal;
using StrayHome.Application.Features.Queries.GetByIdNews;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NewsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet(Name = "GetAllNews")]
        public async Task<ActionResult<IEnumerable<News>>> GetAllNews()
        {
            var command = new GetAllNewsQuery();
            var news = await _mediator.Send(command);
            return Ok(news);
        }
        [HttpGet("{id}", Name = "GetByIdNews")]
        public async Task<ActionResult<News>> GetNewsById(Guid id)
        {
            var command = new GetByIdNewsQuery() { ID = id };
            var news = await _mediator.Send(command);
            return Ok(news);
        }
        [HttpDelete("{id}", Name = "DeleteNews")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteNews(Guid id)
        {
            var command = new DeleteNewsCommand() { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name = "UpdateNews")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateNews([FromBody] UpdateNewsCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // testing purpose
        [HttpPost(Name = "CreateNews")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateNews([FromBody] CreateNewsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
