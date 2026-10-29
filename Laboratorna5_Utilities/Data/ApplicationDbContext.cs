using Microsoft.EntityFrameworkCore;
using Laboratorna5_Utilities.Models;

namespace Laboratorna5_Utilities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<TenantService> TenantServices { get; set; } = null!;
    }
}