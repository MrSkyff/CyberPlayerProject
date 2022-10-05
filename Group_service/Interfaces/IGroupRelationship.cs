using Group_service.Protos.GroupToRelationship;

namespace Group_service.Interfaces
{
    public interface IGroupRelationship
    {
        Task<int[]> GetGameGroupsRelationshipIds(int id);
    }
}
