using LeanworkRecursosHumano.Application.Commands.CreateCandidate;
using LeanworkRecursosHumano.Application.Commands.CreateJobOpening;
using LeanworkRecursosHumano.Application.Commands.DeleteCandidate;
using LeanworkRecursosHumano.Application.Commands.DeleteJobOpening;
using LeanworkRecursosHumano.Application.Commands.UpdateCandidate;
using LeanworkRecursosHumano.Application.Commands.UpdateJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetAllCandidate;
using LeanworkRecursosHumano.Application.Queries.GetAllJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetCandidateById;
using LeanworkRecursosHumano.Application.Queries.GetJobOpeningById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCandidateQuery();

            var candidates = await _mediator.Send(query);

            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCandidateByIdQuery(id);

            var candidate = await _mediator.Send(query);

            return Ok(candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCandidateCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCandidateCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteCandidateCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }
    }
}
