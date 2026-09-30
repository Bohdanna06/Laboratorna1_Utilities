
using Microsoft.EntityFrameworkCore;

namespace Laboratorna3_Utilities.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TenantService> TenantServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantService>()
                .HasKey(ts => new { ts.TenantID, ts.ServiceID });
        }
    }
}
