using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            
            await Task.FromResult(0);

            return Ok(1);
        }
    }
}
