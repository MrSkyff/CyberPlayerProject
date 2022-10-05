using Game_service.Data;
using Game_service.Interfaces;
using Game_service.ProtoModels.Game;
using Game_service.Services.Paginator;
using Grpc.Core;
using System.Runtime.CompilerServices;

namespace Game_service.Services
{
    public class GameService : Game.GameBase
    {
        private readonly IGame gameRepository;

        public GameService(ServiceDbContext dbContext, IGame gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public override Task<GameListResponse> GetGameList(GameListRequest request, ServerCallContext context)
        {
            return Task.FromResult(gameRepository.GetGameListPagedAsync(request.Paginator).Result);
        }

        public override Task<GameByIdResponse> GetGameById(GameByIdRequest reguest, ServerCallContext context)
        {
            return Task.FromResult(gameRepository.GetGameByIdAsync(reguest).Result);
        }

        #region CRUD operations

        public override Task<CreateGameResponse> CreateGame(CreateGameRequest request, ServerCallContext context)
        {
            return Task.FromResult(gameRepository.CreateGameAsync(request).Result);
        }

        public override Task<UpdateGameResponse> UpdateGame(UpdateGameRequest request, ServerCallContext context)
        {
            return Task.FromResult(gameRepository.UpdateGameAsync(request).Result);
        }

        #endregion


    }
}
