using GameServer_service.Data;
using GameServer_service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server_service.Protos.Server;

namespace GameServer_service.Repositories
{
    public class ServerRepository : IServer
    {
        private readonly ServiceDbContext dbContext;

        public ServerRepository(ServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task<ServerByIdResponse> ServerById(ServerByIdRequest serverId)
        //{
        //    var server = await dbContext.Servers.FirstOrDefaultAsync(x => x.Id == serverId.Id);

        //    ServerByIdResponse serverByIdResponse = new ServerByIdResponse();
        //    serverByIdResponse.Server = server;
        //    return serverByIdResponse;
        //}

        //public async Task<ServerListResponse> ServerList()
        //{
        //    var servers = await dbContext.Servers.ToListAsync();
        //    ServerListResponse serverList = new ServerListResponse();
        //    serverList.Servers.AddRange(servers);
        //    return serverList;
        //}

        public async Task<ServerListByGameIdResponse> ServerListByGame(ServerListByGameIdRequest game)
        {
            var servers = await dbContext.Servers.Where(x => x.GameId == game.Id).ToListAsync();
            ServerListByGameIdResponse serverList = new ServerListByGameIdResponse();
            foreach (var item in servers)
            {
                serverList.Servers.Add(new ServerSimpleProto { Id = item.Id, Name = item.Name, Ip = item.Ip, Port = item.Port});
            }
            return serverList;
        }

        //public async Task<ServerListByGroupResponse> ServerListByGroupRequest(ServerListByGroupRequest group)
        //{
        //    var servers = await dbContext.Servers.Where(x => x.GameId == group.Id).ToListAsync();
        //    ServerListByGroupResponse serverList = new ServerListByGroupResponse();
        //    serverList.Servers.AddRange(servers);
        //    return serverList;
        //}
    }
}
