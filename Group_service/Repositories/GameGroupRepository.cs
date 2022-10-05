using Group_service.Data;
using Group_service.Interfaces;
using Group_service.Models.Group;
using Group_service.Protos.GameToGroup;
using Microsoft.EntityFrameworkCore;

namespace Group_service.Repositories
{
    public class GameGroupRepository : IGameGroup
    {
        private readonly ServiceDbContext dbContext;
        private readonly IGroupRelationship groupRelationshipRepository;

        public GameGroupRepository(ServiceDbContext dbContext, IGroupRelationship groupRelationshipRepository)
        {
            this.dbContext = dbContext;
            this.groupRelationshipRepository = groupRelationshipRepository;
        }

        public async Task<GroupListByGameIdResponse> GetGroupListByGameId(GroupListByGameIdRequest request)
        {
            var idList = groupRelationshipRepository.GetGameGroupsRelationshipIds(request.Id).Result;
            var gameGroups = await GetGroupsByIdsAsync(idList);

            GroupListByGameIdResponse responseToProto = new GroupListByGameIdResponse();

            foreach (var item in gameGroups)
            {
                responseToProto.Groups.Add( new GroupSimpleProto { Id = item.Id, Name = item.Name } );
            }

            return responseToProto;
        }

        public async Task<List<GroupModel>> GetGroupsByIdsAsync(int[] ids)
        {
            var model = await dbContext.Groups.Where(g => ids.Contains(g.Id)).ToListAsync();

            return model;
        }
    }
}
