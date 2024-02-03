﻿using LeanworkRecursosHumano.Core.Services;
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
        public async  Task<JsonResult> GetUsers(string filter)
        {
            var usersGitHubDTO = await _gitHubService.GetUsersAsync(filter, 30, 1);

            return Json(usersGitHubDTO);
        }

        [HttpGet("/GithubUsuarios/Details/{id}")]
        public IActionResult Details([FromRoute(Name = "id")] int userId)
        {
            return View();
        }
    }
}