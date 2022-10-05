using MVC_FrontEnd.Areas.Group.Models;

namespace MVC_FrontEnd.Areas.Group.Interfaces
{
    public interface IGroup
    {
        public Task<List<GroupModel>> GetGroupList();
        public Task<GroupModel> GetGroupById(int id);
        public Task<List<GroupModel>> GetGameGroups(int id);
    }
}
