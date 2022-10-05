using Microsoft.EntityFrameworkCore;
using Relationship_service.Models;

namespace Relationship_service.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<GameGroupModel> gameGroups { get; set; }
        public ServiceDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameGroupModel>().HasKey(sc => new { sc.GameId, sc.GroupId });
        }

    }
}
