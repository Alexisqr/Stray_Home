using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.CreateComment;
using StrayHome.Application.Features.Commands.DeleteComment;
using StrayHome.Application.Features.Commands.UpdateComment;
using StrayHome.Application.Features.Queries.GetAllComment;
using StrayHome.Application.Features.Queries.GetByIdComment;
using StrayHome.Domain.Entities;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet(Name = "GetAllComment")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAllComment()
        {
            var command = new GetAllCommentQuery();
            var comments = await _mediator.Send(command);
            return Ok(comments);
        }
        [HttpGet("{id}", Name = "GetByIdComment")]
        public async Task<ActionResult<Comment>> GetCommentById(Guid id)
        {
            var command = new GetByIdCommentQuery() { ID = id };
            var comments = await _mediator.Send(command);
            return Ok(comments);
        }
        [HttpDelete("{id}", Name = "DeleteComment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteComment(Guid id)
        {
            var command = new DeleteCommentCommand() { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name = "UpdateComment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateComment([FromBody] UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // testing purpose
        [HttpPost(Name = "CreateComment")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateComment([FromBody] CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
