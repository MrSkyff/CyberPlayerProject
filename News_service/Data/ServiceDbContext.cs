using Microsoft.EntityFrameworkCore;
using News_service.Models;

namespace News_service.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<NewsModel> News { get; set; }
        public ServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
