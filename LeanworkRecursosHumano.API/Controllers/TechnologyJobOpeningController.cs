using LeanworkRecursosHumano.Application.Commands.CreateTechnologyCandidate;
using LeanworkRecursosHumano.Application.Commands.CreateTechnologyJobOpening;
using LeanworkRecursosHumano.Application.Commands.DeleteTechnologyCandidate;
using LeanworkRecursosHumano.Application.Commands.DeleteTechnologyJobOpening;
using LeanworkRecursosHumano.Application.Commands.UpdateTechnologyCandidate;
using LeanworkRecursosHumano.Application.Commands.UpdateTechnologyJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetAllCandidateTechnology;
using LeanworkRecursosHumano.Application.Queries.GetAllTechnologyJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetTechnologyCandidateById;
using LeanworkRecursosHumano.Application.Queries.GetTechnologyJobOpeningById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyJobOpeningController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TechnologyJobOpeningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTechnologyJobOpeningQuery();

            var technologysJobOpenings = await _mediator.Send(query);

            return Ok(technologysJobOpenings);
        }

        [HttpGet("JobOpening/{id}")]
        public async Task<IActionResult> GetByIdJobOpening(int id)
        {
            var query = new GetTechnologyJobOpeningByIdQuery(id);

            var JobOpeningByCandidate = await _mediator.Send(query);

            return Ok(JobOpeningByCandidate);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTechnologyJobOpeningCommand command)
        {
            var idJobOpening = await _mediator.Send(command);

            return Ok(idJobOpening);
        }

        [HttpPut("JobOpening/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTechnologyJobOpeningCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("JobOpening/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteTechnologyJobOpeningCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }


    }
}
