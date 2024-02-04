using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
