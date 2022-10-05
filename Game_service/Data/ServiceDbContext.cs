using Game_service.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_service.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<GameGroup>().HasKey(key => new { key.GameId, key.GroupId } );
        }

    }
}
