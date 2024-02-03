using LeanworkRecursosHumano.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.WEB.Controllers
{
    public class GithubUsuariosController : Controller
    {
        private readonly IGithubService _gitHubService;

        public GithubUsuariosController(IGithubService githubService)
        {
            _gitHubService = githubService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async  Task<JsonResult> GetUsers()
        {
            var usersGitHubDTO = await _gitHubService.GetUsersAsync();

            return Json(usersGitHubDTO);
        }

        [HttpGet("/GithubUsuarios/Details/{userLogin}")]
        public async Task<IActionResult> Details([FromRoute(Name = "userLogin")] string userLogin)
        {
            var userDetails = await _gitHubService.GetUserByLoginNameAsync(userLogin);

            return View(userDetails);
        }
    }
}
