using Grpc.Core;
using Relationship_service.Interfaces;
using Relationship_service.Protos.GroupRelationShip;

namespace Relationship_service.Services
{
    public class GroupRelationshipService : GroupToRelationship.GroupToRelationshipBase
    {
        private readonly IGroupRelationship groupRelationshitRepasitory;

        public GroupRelationshipService(IGroupRelationship groupRelationshitRepasitory)
        {
            this.groupRelationshitRepasitory = groupRelationshitRepasitory;
        }

        public override Task<GruopIdsByGameIdResponse> TransferGroupIdsByGameId(GruopIdsByGameIdRequest request, ServerCallContext context)
        {
            var model = groupRelationshitRepasitory.GetGruopIdsByGameAsync(request.Id).Result;
            return Task.FromResult(model);
        }
    }
}
