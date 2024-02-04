using LeanworkRecursosHumano.Application.Commands.CreateTechnology;
using LeanworkRecursosHumano.Application.Commands.DeleteTechnology;
using LeanworkRecursosHumano.Application.Commands.UpdateTechnology;
using LeanworkRecursosHumano.Application.Queries.GetAllTechnology;
using LeanworkRecursosHumano.Application.Queries.GetTechnologyById;
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
    public class TechnologyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnologyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTechnologyQuery();

            var technologys = await _mediator.Send(query);

            return Ok(technologys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTechnologyByIdQuery(id);

            var technology = await _mediator.Send(query);

            return Ok(technology);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTechnologyCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTechnologyCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteTechnologyCommand(id);

            await _mediator.Send(query);

            return NoContent();
        }
    }
}
