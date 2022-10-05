using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Group.Models;
using MVC_FrontEnd.Areas.Server.Models;

namespace MVC_FrontEnd.Areas.Game.Interfaces
{
    public interface IGame
    {
        public Task<List<GameSimpleModel>> GetGameListAsync();
        public Task<GameModel> GetGameByIdAsync(int id);
        public Task<List<GroupSimpleModel>> GetGroupListByGameIdAsync(int id);
        public Task<List<ServerSimpleModel>> GetServerListByGameIdAsync(int id);
    }
}
