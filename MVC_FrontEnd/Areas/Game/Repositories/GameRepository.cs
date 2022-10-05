using Grpc.Net.Client;
using MVC_FrontEnd.Areas.Game.Interfaces;
using MVC_FrontEnd.Areas.Game.ViewModels;
using MVC_FrontEnd.Areas.Game.Protos.Game;
using System.Text.Json;
using MVC_FrontEnd.Areas.Game.Models;
using MVC_FrontEnd.Areas.Group.Models;
using MVC_FrontEnd.Areas.Server.Models;
using MVC_FrontEnd.Areas.Game.Protos.Group;

namespace MVC_FrontEnd.Areas.Game.Repositories
{

    public class GameRepository : IGame
    {
        private readonly IConfiguration config;

        public GameRepository(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<List<GameSimpleModel>> GetGameListAsync()
        {
            List<GameSimpleModel> games = new List<GameSimpleModel>();
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
                var client = new GameToGame.GameToGameClient(channel);
                var result = await client.GetGameListAsync(new GameListRequest { });
                games = JsonSerializer.Deserialize<List<GameSimpleModel>>
                         (result.Games.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                return games;
            }
            catch (Exception)
            {
                games.Add(new GameSimpleModel { Id = 0 });
                return games;
            }
        }

        public async Task<GameModel> GetGameByIdAsync(int id)
        {
            using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GameService").Value);
            var client = new GameToGame.GameToGameClient(channel);
            var result = await client.GetGameByIdAsync(new GameByIdRequest { Id = id });

            var model = JsonSerializer.Deserialize<GameModel>
                         (result.Game.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return model;
        }

        public async Task<List<GroupSimpleModel>> GetGroupListByGameIdAsync(int id)
        {

            List<GroupSimpleModel> model = new List<GroupSimpleModel>();
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("GroupService").Value);
                var client = new GameToGroup.GameToGroupClient(channel);
                var result = await client.GetGroupListByGameIdAsync(new GroupListByGameIdRequest { Id = id });
                model = JsonSerializer.Deserialize<List<GroupSimpleModel>>
                               (result.Groups.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            }
            catch (Exception)
            {
                model.Add(new GroupSimpleModel { Id = 0 } );
            }
            return model;
        }

        public async Task<List<ServerSimpleModel>> GetServerListByGameIdAsync(int id)
        {
            List<ServerSimpleModel> servers = new List<ServerSimpleModel>
            {
               new ServerSimpleModel { Id = 1, Name = "aaaaaaaaaa" },
               new ServerSimpleModel { Id = 1, Name = "bbbbbbbbb" },
               new ServerSimpleModel { Id = 1, Name = "vvvvvvvv" },
               new ServerSimpleModel { Id = 1, Name = "dfffffffff" },
               new ServerSimpleModel { Id = 1, Name = "dddddddddddd" }
            };
            return servers;
        }
    }
}
