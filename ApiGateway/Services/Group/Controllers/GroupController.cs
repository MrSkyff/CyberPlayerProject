using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Services.Group.Controllers
{       
    [ApiController]
    [Route("Api/[controller]")]
    public class GroupController : ControllerBase
    {
        [HttpGet]
        [Route("List")]
        public async Task<string> GetGroupList()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7051");

            var client = new Groups.GroupsClient(channel);
            var answer = await client.GetGroupListAsync(new EmptyGroup { });

            return answer.Groups.ToString();
        }

        [HttpGet]
        [Route("ListByGame")]
        public async Task<string> GetGroupListByGameId(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7241");

            var client = new Groups.GroupsClient(channel);
            var answer = await client.GetGroupListByIdsAsync( new GroupsByGameId {  Id = id } );

            return answer.Groups.ToString();
        }
    }
}
