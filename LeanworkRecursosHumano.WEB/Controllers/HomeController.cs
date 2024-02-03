using LeanworkRecursosHumano.Core.Services;
using LeanworkRecursosHumano.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGithubService _gitHubService;

        public HomeController(ILogger<HomeController> logger, IGithubService githubService)
        {
            _logger = logger;
            _gitHubService = githubService;
        }

        public IActionResult Index()
        {
            var usuarioGitHubDTO = _gitHubService.GetUsuariosAsync("",30,2);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
