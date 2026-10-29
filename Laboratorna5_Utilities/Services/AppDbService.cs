using Laboratorna5_Utilities.Data;
using Laboratorna5_Utilities.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboratorna5_Utilities.Services
{
    public class AppDbService
    {
        private readonly ApplicationDbContext _context;

        public AppDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==================== 1. ПОСЛУГИ (Services) ====================
        public async Task<List<Laboratorna5_Utilities.Models.Service>> GetServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Laboratorna5_Utilities.Models.Service?> GetServiceByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task AddServiceAsync(Laboratorna5_Utilities.Models.Service entity)
        {
            _context.Services.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Laboratorna5_Utilities.Models.Service entity)
        {
            _context.Services.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var entity = await _context.Services.FindAsync(id);
            if (entity != null)
            {
                _context.Services.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // ==================== 2. МЕШКАНЦІ (Tenants) ====================
        public async Task<List<Tenant>> GetTenantsAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task<Tenant?> GetTenantByIdAsync(int id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public async Task AddTenantAsync(Tenant entity)
        {
            _context.Tenants.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTenantAsync(Tenant entity)
        {
            _context.Tenants.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTenantAsync(int id)
        {
            var entity = await _context.Tenants.FindAsync(id);
            if (entity != null)
            {
                _context.Tenants.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // ==================== 3. НАРАХОВАНІ ПОСЛУГИ (TenantServices) ====================
        public async Task<List<TenantService>> GetTenantServicesAsync()
        {
            return await _context.TenantServices
                .Include(ts => ts.Tenant)
                .Include(ts => ts.Service)
                .ToListAsync();
        }

        public async Task AddTenantServiceAsync(TenantService entity)
        {
            _context.TenantServices.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTenantServiceAsync(int id)
        {
            var entity = await _context.TenantServices.FindAsync(id);
            if (entity != null)
            {
                _context.TenantServices.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}