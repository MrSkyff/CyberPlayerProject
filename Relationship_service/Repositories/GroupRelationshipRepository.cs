using Microsoft.EntityFrameworkCore;
using Relationship_service.Data;
using Relationship_service.Interfaces;
using Relationship_service.Protos.GroupRelationShip;

namespace Relationship_service.Repositories
{
    public class GroupRelationshipRepository : IGroupRelationship
    {
        private readonly ServiceDbContext dbContext;

        public GroupRelationshipRepository(ServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GruopIdsByGameIdResponse> GetGruopIdsByGameAsync(int id)
        {
            var model = dbContext.gameGroups.Where(x => x.GameId == id).ToListAsync();
            GruopIdsByGameIdResponse groupIds = new GruopIdsByGameIdResponse();
            foreach (var item in model.Result)
            {
                groupIds.Ids.Add(item.GroupId);
            }

            return groupIds;
        }
    }
}
