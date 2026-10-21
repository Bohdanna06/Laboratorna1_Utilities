using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laboratorna4_Utilities.Data;
using Laboratorna4_Utilities.Models;

namespace Laboratorna4_Utilities.Pages.TenantServices
{
    public class DetailsModel : PageModel
    {
        private readonly Laboratorna4_Utilities.Data.ApplicationDbContext _context;

        public DetailsModel(Laboratorna4_Utilities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
