using LeanworkRecursosHumano.Application.Commands.CreateInterview;
using LeanworkRecursosHumano.Application.Commands.DeleteCandidateJobOpening;
using LeanworkRecursosHumano.Application.Commands.UpdateCandidateJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetAllByIdCandidate;
using LeanworkRecursosHumano.Application.Queries.GetAllCandidateJobOpening;
using LeanworkRecursosHumano.Application.Queries.GetInfoReportByCandidateByTechnology;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using FastReport;
using FastReport.Export.PdfSimple;


namespace LeanworkRecursosHumano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InterviewController(IMediator mediator,IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpPost]
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

        [HttpGet("finishScreening/")]
        public async Task<IActionResult> FinishScreening()
        {
            var queryReport = new GetInfoReportByCandidateByTechnologyQuery();

            var listWeights = await _mediator.Send(queryReport);

            var report = new Report();

            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "RelCandidatos.frx");
            report.Load(filePath);

            report.Dictionary.RegisterBusinessObject(listWeights, "listCandidates", 10, true);
            report.Prepare();

            var pdfExport = new PDFSimpleExport();

            using (var ms = new MemoryStream())
            {
                pdfExport.Export(report, ms);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms.ToArray(), "application/pdf", "RelatorioCandidatos.pdf");
            }

        }

    }
}
