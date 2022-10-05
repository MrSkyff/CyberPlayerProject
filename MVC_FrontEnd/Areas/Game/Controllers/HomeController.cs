using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Game.ViewModels;
using MVC_FrontEnd.Areas.Group.Interfaces;
using MVC_FrontEnd.Areas.Group.Models;

namespace MVC_FrontEnd.Areas.Game.Controllers
{
    [Area("Game")]
    public class HomeController : Controller
    {
        private readonly IGame gamesRepository;

        public HomeController(IGame gamesRepository, IGroup groupRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        [Route("Games")]
        public async Task<IActionResult> Index()
        {
            var model = await gamesRepository.GetGameListAsync();
            return View(model);
        }

        [Route("Game/{id?}")]
        public async Task<IActionResult> Game(int id)
        {
            var model = await gamesRepository.GetGameByIdAsync(id);
            return View(model);
        }
    }
}
