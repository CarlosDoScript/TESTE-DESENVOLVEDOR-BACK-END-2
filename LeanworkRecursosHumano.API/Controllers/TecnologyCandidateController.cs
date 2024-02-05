using LeanworkRecursosHumano.Application.Commands.CreateInterview;
using LeanworkRecursosHumano.Application.Commands.CreateTechnology;
using LeanworkRecursosHumano.Application.Commands.CreateTechnologyCandidate;
using LeanworkRecursosHumano.Application.Commands.DeleteCandidateJobOpening;
using LeanworkRecursosHumano.Application.Commands.DeleteTechnologyCandidate;
using LeanworkRecursosHumano.Application.Commands.UpdateCandidateJobOpening;
using LeanworkRecursosHumano.Application.Commands.UpdateTechnologyCandidate;
using LeanworkRecursosHumano.Application.Queries.GetAllByIdCandidate;
using LeanworkRecursosHumano.Application.Queries.GetAllCandidateJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetAllCandidateTechnology;
using LeanworkRecursosHumano.Application.Queries.GetTechnologyCandidateById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TecnologyCandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TecnologyCandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTechnologyCandidateQuery();

            var technologysCandidates = await _mediator.Send(query);

            return Ok(technologysCandidates);
        }

        [HttpGet("candidate/{id}")]
        public async Task<IActionResult> GetByIdCandidate(int id)
        {
            var query = new GetTechnologyCandidateByIdQuery(id);

            var JobOpeningByCandidate = await _mediator.Send(query);

            return Ok(JobOpeningByCandidate);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTecnologyCandidateCommand command)
        {
            var idCandidate = await _mediator.Send(command);

            return Ok(idCandidate);
        }

        [HttpPut("candidate/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTechnologyCandidateCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("candidate/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteTechnologyCandidateCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }

    }
}
