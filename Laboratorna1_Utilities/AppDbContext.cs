
using Microsoft.EntityFrameworkCore;

namespace Laboratorna1_Utilities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TenantService> TenantServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=Utilities;User ID=root;Password=bohdanna1106;";
          
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantService>()
                .HasKey(ts => new { ts.TenantID, ts.ServiceID });
        }
    }
}
