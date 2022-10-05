using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Services.GameServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameServerController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public async Task<string> GetServerList()
        {

            using var channel = GrpcChannel.ForAddress("https://localhost:7078");

            var client = new Servers.ServersClient(channel);
            var gameServerAnswer = await client.GetServerListAsync(new EmptyServer { });

            var display = gameServerAnswer.Servers;

            return display.ToString();
        }

        [HttpGet]
        [Route("listbygame")]
        public async Task<string> GetServerByGame(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7078");

            var client = new Servers.ServersClient(channel);
            var gameServerAnswer = await client.GetServersByGameAsync(new GetServerByGameId { Id = id });

            var display = gameServerAnswer.Servers;

            return display.ToString();
        }
    }
}
