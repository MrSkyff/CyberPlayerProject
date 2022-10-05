using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Group.Interfaces;
using MVC_FrontEnd.Areas.Group.Repositories;
using MVC_FrontEnd.Areas.Group.ViewModels;

namespace MVC_FrontEnd.Areas.Group.Controllers
{
    [Area("Group")]
    public class HomeController : Controller
    {
        private readonly IGroup groupRepository;
        private readonly IGame gameRepository;

        public HomeController(IGroup groupRepository, IGame gameRepository)
        {
            this.groupRepository = groupRepository;
            this.gameRepository = gameRepository;
        }

        //[Route("Groups")]
        public async Task<IActionResult> Index()
        {
            return View(await groupRepository.GetGroupList());
        }

        public async Task<IActionResult> Group(int id)
        {

            var model = await groupRepository.GetGroupById(id);
              
            return View(model);
        }
    }
}
