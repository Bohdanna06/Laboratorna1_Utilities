
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laboratorna4_Utilities.Models;

namespace Laboratorna4_Utilities.Pages.TenantServices
{
    public class CreateModel : PageModel
    {
        private readonly Laboratorna4_Utilities.Data.ApplicationDbContext _context;

        public CreateModel(Laboratorna4_Utilities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "ID");
        ViewData["TenantID"] = new SelectList(_context.Tenants, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public TenantService TenantService { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TenantServices.Add(TenantService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
