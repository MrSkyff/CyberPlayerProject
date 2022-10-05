using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Server.Models;

namespace MVC_FrontEnd.Areas.Game.ViewComponents
{
    public class GameServersViewComponent : ViewComponent
    {
        private readonly IGame gameRepository;

        public GameServersViewComponent(IGame gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int gameId)
        {
            var item = await GetServerList(gameId);
            return View(item);
        }

        private Task<List<ServerSimpleModel>> GetServerList(int gameId)
        {
            return gameRepository.GetServerListByGameIdAsync(gameId);
        }
    }
}
