using LeanworkRecursosHumano.Application.Commands.LoginUser;
using LeanworkRecursosHumano.Application.ViewModels;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserModel = await _mediator.Send(command);

            if (loginUserModel == null)
            {
                return BadRequest("Nome de Usuário ou Senha Incorretos.");
            }

            return Ok(loginUserModel);
        }
    }
}
