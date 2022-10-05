using GameServer_service.Interfaces;
using Grpc.Core;
using Server_service.Protos.Server;

namespace Server_service.Services
{
    public class GameToServerService : GameToServer.GameToServerBase
    {
        private readonly IServer serverRepository;

        public GameToServerService(IServer serverRepository)
        {
            this.serverRepository = serverRepository;
        }

        public override Task<ServerListByGameIdResponse> GetServerListByGameId(ServerListByGameIdRequest game, ServerCallContext context)
        {
            return Task.FromResult(serverRepository.ServerListByGame(game).Result);
        }
    }
}
