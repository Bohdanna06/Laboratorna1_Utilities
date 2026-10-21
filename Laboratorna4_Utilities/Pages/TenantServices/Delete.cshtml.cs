
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laboratorna4_Utilities.Models;

namespace Laboratorna4_Utilities.Pages.TenantServices
{
    public class DeleteModel : PageModel
    {
        private readonly Laboratorna4_Utilities.Data.ApplicationDbContext _context;

        public DeleteModel(Laboratorna4_Utilities.Data.ApplicationDbContext context)
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

            var tenantservice = await _context.TenantServices.FirstOrDefaultAsync(m => m.ID == id);

            if (tenantservice == null)
            {
                return NotFound();
            }
            else
            {
                TenantService = tenantservice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantservice = await _context.TenantServices.FindAsync(id);
            if (tenantservice != null)
            {
                TenantService = tenantservice;
                _context.TenantServices.Remove(TenantService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
