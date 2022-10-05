using Game_service.Models;
using Game_service.Services.Paginator;

namespace Game_service.ComboModels
{
    public class GameListComboModel
    {
        public List<GameModel> Games { get; set; }
        public PaginatorModel Paginator { get; set; }
    }
}
