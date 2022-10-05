using Group_service.Interfaces;
using Group_service.Protos.GameToGroup;
using Group_service.Protos.GroupToRelationship;
using Grpc.Core;

namespace Group_service.Services
{
    public class GameToGroupService : GameToGroup.GameToGroupBase
    {
        private readonly IGameGroup gameGroupRepository;

        public GameToGroupService(IGameGroup gameGroupRepository)
        {
            this.gameGroupRepository = gameGroupRepository;
        }

        public override Task<GroupListByGameIdResponse> GetGroupListByGameId(GroupListByGameIdRequest request, ServerCallContext context)
        {
            var model = gameGroupRepository.GetGroupListByGameId(request).Result;

            return Task.FromResult(model);
        }
    }
}
