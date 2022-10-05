using Server_service.Protos.Server;

namespace GameServer_service.Interfaces
{
    public interface IServer
    {
        //public Task<ServerByIdResponse> ServerById(ServerByIdRequest serverId);
        //public Task<ServerListResponse> ServerList();
        public Task<ServerListByGameIdResponse> ServerListByGame(ServerListByGameIdRequest serverListByGameRequest);
        //public Task<ServerListByGroupResponse> ServerListByGroupRequest(ServerListByGroupRequest serverListByGroupRequest);
    }
}
