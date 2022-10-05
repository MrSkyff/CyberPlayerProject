using Idenity_service.Models;
using Microsoft.EntityFrameworkCore;

namespace Idenity_service.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public ServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
