using Grpc.Core;
using Grpc.Net.Client;
using MVC_FrontEnd.Areas.Group.Interfaces;
using MVC_FrontEnd.Areas.Group.Models;
using System.Text.Json;

namespace MVC_FrontEnd.Areas.Group.Repositories
{
    public class GroupRepository : IGroup
    {
        private readonly IConfiguration config; //config.GetSection("ServiceRouting").GetSection("GroupService").Value

        public GroupRepository(IConfiguration config)
        {
            this.config = config;
        }

        public Task<List<GroupModel>> GetGameGroups(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupModel> GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupModel>> GetGroupList()
        {
            throw new NotImplementedException();
        }
    }
}
