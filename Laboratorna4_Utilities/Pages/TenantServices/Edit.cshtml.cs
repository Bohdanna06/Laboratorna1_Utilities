
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboratorna4_Utilities.Models;

namespace Laboratorna4_Utilities.Pages.TenantServices
{
    public class EditModel : PageModel
    {
        private readonly Laboratorna4_Utilities.Data.ApplicationDbContext _context;

        public EditModel(Laboratorna4_Utilities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TenantService TenantService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantservice =  await _context.TenantServices.FirstOrDefaultAsync(m => m.ID == id);
            if (tenantservice == null)
            {
                return NotFound();
            }
            TenantService = tenantservice;
           ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "ID");
           ViewData["TenantID"] = new SelectList(_context.Tenants, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TenantService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantServiceExists(TenantService.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TenantServiceExists(int id)
        {
            return _context.TenantServices.Any(e => e.ID == id);
        }
    }
}
