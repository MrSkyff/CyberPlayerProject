using Relationship_service.Protos.GroupRelationShip;

namespace Relationship_service.Interfaces
{
    public interface IGroupRelationship
    {
        Task<GruopIdsByGameIdResponse> GetGruopIdsByGameAsync(int id);
    }
}
