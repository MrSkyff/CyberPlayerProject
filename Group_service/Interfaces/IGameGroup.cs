using Group_service.Models.Group;
using Group_service.Protos.GameToGroup;

namespace Group_service.Interfaces
{
    public interface IGameGroup
    {
        Task<GroupListByGameIdResponse> GetGroupListByGameId(GroupListByGameIdRequest request);
        Task<List<GroupModel>> GetGroupsByIdsAsync(int[] ids);
    }
}
