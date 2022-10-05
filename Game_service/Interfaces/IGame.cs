using Game_service.ProtoModels.Game;

namespace Game_service.Interfaces
{
    public interface IGame
    {
        Task<GameByIdResponse> GetGameByIdAsync(GameByIdRequest request);
        Task<GameListResponse> GetGameListAsync();
        Task<GameListResponse> GetGameListPagedAsync(PaginatorGameProto paginator);
        Task<CreateGameResponse> CreateGameAsync(CreateGameRequest request);
        Task<UpdateGameResponse> UpdateGameAsync(UpdateGameRequest request);
    }
}
