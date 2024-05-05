using MediatR;
using Microsoft.AspNetCore.Mvc;
using StrayHome.Application.Features.Commands.AddListOfAnimals;
using StrayHome.Application.Features.Commands.CreateAnimal;
using StrayHome.Application.Features.Commands.DeleteAnimal;
using StrayHome.Application.Features.Commands.GetAnimalInExcel;
using StrayHome.Application.Features.Commands.UpdateAnimal;
using StrayHome.Application.Features.Queries.GetAllAnimal;
using StrayHome.Application.Features.Queries.GetByIdAnimal;
using StrayHome.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace StrayHome.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AnimalController : ControllerBase
    {

        private readonly IMediator _mediator;
       public AnimalController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
        }
        [HttpGet(Name = "GetAllAnimal")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAllAnimal()
        {
            var command = new GetAllAnimalQuery();
            var animals = await _mediator.Send(command);
            return Ok(animals);
        }
        [HttpGet("{id}", Name = "GetByIdAnimal")]
        public async Task<ActionResult<Animal>> GetAnimalById(Guid id)
        {
            var command = new GetByIdAnimalQuery() { ID = id };
            var animals = await _mediator.Send(command);
            return Ok(animals);
        }
        [HttpDelete("{id}", Name = "DeleteAnimal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAnimal(Guid id)
        {
            var command = new DeleteAnimalCommand() { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name = "UpdateAnimal")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAnimal([FromBody] UpdateAnimalCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // testing purpose
        [HttpPost(Name = "CreateAnimal")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAnimal([FromBody] CreateAnimalCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("AddListOfAnimals")]
        public async Task<ActionResult<int>> AddListOfAnimals(IFormFile file, Guid id)
        {
            var command = new AddListOfAnimalsCommand
            {
                ID = id,
                File = file
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("GetAnimalsInExcel", Name = "GetAnimalsInExcel")]
      
        public async Task<ActionResult> GetAnimalsInExcel(Guid id)
        {

            //User

            // тут треба реалізувати або захешувати id юзера

            var command = new GetAnimalsInExcelCommand
            {
                ID = id
            };
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
