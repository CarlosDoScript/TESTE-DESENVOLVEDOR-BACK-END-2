using LeanworkRecursosHumano.Application.Commands.CreateJobOpening;
using LeanworkRecursosHumano.Application.Commands.DeleteJobOpening;
using LeanworkRecursosHumano.Application.Commands.UpdateJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetAllJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetJobOpeningById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOpeningController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobOpeningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllJobOpeningQuery();

            var technologys = await _mediator.Send(query);

            return Ok(technologys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetJobOpeningByIdQuery(id);

            var technology = await _mediator.Send(query);

            return Ok(technology);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateJobOpeningCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateJobOpeningCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteJobOpeningCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }
    }
}
