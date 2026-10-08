using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboratorna3_Utilities.Models;

namespace Laboratorna3_Utilities.Controllers
{
    public class TenantServicesController : Controller
    {
        private readonly AppDbContext _context;

        public TenantServicesController(AppDbContext context)
        {
            _context = context;
        }

        // READ: Перегляд призначених послуг
        public async Task<IActionResult> Index()
        {
            var tenantServices = _context.TenantServices
                .Include(ts => ts.Tenant)
                .Include(ts => ts.Service);
            return View(await tenantServices.ToListAsync());
        }

        // CREATE: Форма призначення послуги мешканцю (GET)
        public IActionResult Create()
        {
            ViewData["TenantID"] = new SelectList(_context.Tenants, "ID", "FullName");
            ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "ServiceName");
            return View();
        }

        // CREATE: Збереження призначення (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TenantService tenantService)
        {
            // Видаляємо перевірку навігаційних властивостей
            ModelState.Remove("Tenant");
            ModelState.Remove("Service");

            // Перевіряємо, чи існує вже таке призначення
            bool exists = await _context.TenantServices
                .AnyAsync(ts => ts.TenantID == tenantService.TenantID && ts.ServiceID == tenantService.ServiceID);

            if (exists)
            {
                ModelState.AddModelError("", "Ця послуга вже призначена для даного мешканця.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(tenantService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TenantID"] = new SelectList(_context.Tenants, "ID", "FullName", tenantService.TenantID);
            ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "ServiceName", tenantService.ServiceID);
            return View(tenantService);
        }

        // DELETE: Підтвердження вилучення послуги у мешканця (GET)
        public async Task<IActionResult> Delete(int? tenantId, int? serviceId)
        {
            if (tenantId == null || serviceId == null) return NotFound();

            var tenantService = await _context.TenantServices
                .Include(ts => ts.Tenant)
                .Include(ts => ts.Service)
                .FirstOrDefaultAsync(m => m.TenantID == tenantId && m.ServiceID == serviceId);

            if (tenantService == null) return NotFound();

            return View(tenantService);
        }

        // DELETE: Видалення призначення (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int tenantId, int serviceId)
        {
            var tenantService = await _context.TenantServices.FindAsync(tenantId, serviceId);
            if (tenantService != null)
            {
                _context.TenantServices.Remove(tenantService);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}