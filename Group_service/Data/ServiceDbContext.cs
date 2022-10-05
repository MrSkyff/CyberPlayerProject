using Group_service.Models.Group;
using Microsoft.EntityFrameworkCore;


namespace Group_service.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<GroupModel> Groups { get; set; }
        public ServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
