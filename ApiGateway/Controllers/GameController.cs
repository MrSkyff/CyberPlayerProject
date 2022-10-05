using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {




        [HttpGet]
        [Route("list")]
        public async Task<string> GetGameList()
        {

            using var channelGames = GrpcChannel.ForAddress("https://localhost:7241");

            var gamesClient = new Games.GamesClient(channelGames);
            var gameListAnswer = await gamesClient.GetGameListAsync(new EmptyGame { });

            var display = gameListAnswer.Games;



            return display.ToString();
        }

        [HttpGet]
        [Route("show")]
        public async Task<string> GetGameById(int id)
        {

            using var channelGames = GrpcChannel.ForAddress("https://localhost:7241");

            var gamesClient = new Games.GamesClient(channelGames);
            var gameListAnswer = await gamesClient.GetGameListAsync(new EmptyGame { });

            var display = gameListAnswer.Games;

            var t = display[id-1];

            return t.ToString();
        }





    }
}
