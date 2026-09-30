using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorna3_Utilities.Models;

namespace Laboratorna3_Utilities.Controllers
{
    public class TenantsController : Controller
    {
        private readonly AppDbContext _context;

        public TenantsController(AppDbContext context)
        {
            _context = context;
        }

        // (Read)
        public async Task<IActionResult> Index()
        {
            var tenants = await _context.Tenants.ToListAsync();
            return View(tenants);
        }

        
        // GET: Tenants/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Services = await _context.Services.ToListAsync();
            return View();
        }

        // POST: Tenants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tenant tenant, int[] selectedServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenant);
                await _context.SaveChangesAsync(); // Зберігаємо мешканця, щоб отримати його ID

                if (selectedServices != null && selectedServices.Length > 0)
                {
                    foreach (var serviceId in selectedServices)
                    {
                        _context.TenantServices.Add(new TenantService
                        {
                            TenantID = tenant.ID,
                            ServiceID = serviceId
                        });
                    }
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Services = await _context.Services.ToListAsync();
            return View(tenant);
        }



        // 3. Редагування - GET 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null) return NotFound();

            ViewBag.Services = await _context.Services.ToListAsync();
            ViewBag.SelectedServices = await _context.TenantServices
                .Where(ts => ts.TenantID == id)
                .Select(ts => ts.ServiceID)
                .ToListAsync();

            return View(tenant);
        }

        // 3. Редагування - POST (Оновлення в БД)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tenant tenant, int[] selectedServices)
        {
            if (id != tenant.ID) return NotFound(); 

            if (ModelState.IsValid)
            {
                _context.Update(tenant);
              
                var oldServices = _context.TenantServices.Where(ts => ts.TenantID == id);
                _context.TenantServices.RemoveRange(oldServices);

                if (selectedServices != null)
                {
                    foreach (var serviceId in selectedServices)
                    {
                        _context.TenantServices.Add(new TenantService
                        {
                            TenantID = tenant.ID,
                            ServiceID = serviceId
                        });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Services = await _context.Services.ToListAsync();
            return View(tenant);
        }

        // 4. Видалення - GET (Підтвердження видалення)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tenant = await _context.Tenants.FirstOrDefaultAsync(m => m.ID == id);
            if (tenant == null) return NotFound();

            return View(tenant);
        }

        // 4. Видалення - POST (Видалення з БД)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant != null)
            {
                _context.Tenants.Remove(tenant);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}