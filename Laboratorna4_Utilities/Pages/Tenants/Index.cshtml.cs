using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laboratorna4_Utilities.Data;
using Laboratorna4_Utilities.Models;

namespace Laboratorna4_Utilities.Pages.Tenants
{
    public class IndexModel : PageModel
    {
        private readonly Laboratorna4_Utilities.Data.ApplicationDbContext _context;

        public IndexModel(Laboratorna4_Utilities.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tenant> Tenant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tenant = await _context.Tenants.ToListAsync();
        }
    }
}
