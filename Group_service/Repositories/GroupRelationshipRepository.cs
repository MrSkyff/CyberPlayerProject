using Group_service.Interfaces;
using Group_service.Protos.GroupToRelationship;
using Grpc.Net.Client;
using System.Text.Json;

namespace Group_service.Repositories
{
    public class GroupRelationshipRepository : IGroupRelationship
    {
        private readonly IConfiguration config;

        public GroupRelationshipRepository(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<int[]> GetGameGroupsRelationshipIds(int id)
        {
            int[] model;
            try
            {
                using var channel = GrpcChannel.ForAddress(config.GetSection("ServiceRouting").GetSection("RelationshipService").Value);
                var client = new GroupToRelationship.GroupToRelationshipClient(channel);
                var result = await client.TransferGroupIdsByGameIdAsync( new GroupsByGameRequest { Id = id } );
                model = JsonSerializer.Deserialize<int[]>
                     (result.Ids.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            }
            catch (Exception)
            {

                throw;
            }

            return model;
        }
    }
}
