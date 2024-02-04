using LeanworkRecursosHumano.Application.Commands.CreateInterview;
using LeanworkRecursosHumano.Application.Commands.CreateJobOpening;
using LeanworkRecursosHumano.Application.Commands.DeleteCandidateJobOpening;
using LeanworkRecursosHumano.Application.Commands.DeleteJobOpening;
using LeanworkRecursosHumano.Application.Commands.UpdateCandidateJobOpening;
using LeanworkRecursosHumano.Application.Commands.UpdateJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetAllByIdCandidate;
using LeanworkRecursosHumano.Application.Queries.GetAllCandidateJobOpening;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InterviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCandidateJobOpeningQuery();

            var candidatesInterviews = await _mediator.Send(query);

            return Ok(candidatesInterviews);
        }

        [HttpGet("candidate/{id}")]
        public async Task<IActionResult> GetByIdCandidateAsync(int id)
        {
            var query = new GetCandidateJobOpeningByIdCandidateQuery(id);

            var JobOpeningByCandidate = await _mediator.Send(query);

            return Ok(JobOpeningByCandidate);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateInterviewCommand command)
        {
            var idCandidate = await _mediator.Send(command);

            return Ok(idCandidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCandidateJobOpeningCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteCandidateJobOpeningCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }
    }
}
