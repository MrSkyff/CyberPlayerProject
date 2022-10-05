using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Group.Models;

namespace MVC_FrontEnd.Areas.Game.ViewComponents
{
    public class GameGroupsViewComponent : ViewComponent
    {
        private readonly IGame gameRepository;

        public GameGroupsViewComponent(IGame gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int gameId)
        {
            var item = await GetGroupList(gameId);
            return View(item);
        }

        private Task<List<GroupSimpleModel>> GetGroupList(int gameId)
        {
            var model = gameRepository.GetGroupListByGameIdAsync(gameId);
            return model;
        }


    }
}
