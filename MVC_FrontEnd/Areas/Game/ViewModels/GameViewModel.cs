using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Group.Models;

namespace MVC_FrontEnd.Areas.Game.ViewModels
{
    public class GameViewModel
    {
        public GameModel Game { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
    }
}
