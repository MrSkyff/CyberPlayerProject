using Microsoft.EntityFrameworkCore;
using Server_service.Models;

namespace GameServer_service.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<ServerModel> Servers { get; set; }
        public ServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
