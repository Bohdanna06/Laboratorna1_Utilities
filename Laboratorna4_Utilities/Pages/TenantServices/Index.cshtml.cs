
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laboratorna4_Utilities.Models;

namespace Laboratorna4_Utilities.Pages.TenantServices
{
    public class IndexModel : PageModel
    {
        private readonly Laboratorna4_Utilities.Data.ApplicationDbContext _context;

        public IndexModel(Laboratorna4_Utilities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TenantService> TenantService { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TenantService = await _context.TenantServices
                .Include(t => t.Service)
                .Include(t => t.Tenant).ToListAsync();
        }
    }
}
