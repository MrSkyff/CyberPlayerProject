using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;

namespace MVC_FrontEnd.Areas.Game.ViewComponents
{
    public class GameNewsViewComponent : ViewComponent
    {
        private readonly IGame gameRepository;

        public GameNewsViewComponent(IGame gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }

    }
}
