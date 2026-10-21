using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorna4_Utilities.Data;
using Laboratorna4_Utilities.Models;

namespace Laboratorna4_Utilities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TenantServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TenantServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenantService>>> GetTenantServices()
        {
            return await _context.TenantServices.ToListAsync();
        }

        // GET: api/TenantServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TenantService>> GetTenantService(int id)
        {
            var tenantService = await _context.TenantServices.FindAsync(id);

            if (tenantService == null)
            {
                return NotFound();
            }

            return tenantService;
        }

        // PUT: api/TenantServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenantService(int id, TenantService tenantService)
        {
            if (id != tenantService.ID)
            {
                return BadRequest();
            }

            _context.Entry(tenantService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TenantServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TenantService>> PostTenantService(TenantService tenantService)
        {
            _context.TenantServices.Add(tenantService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTenantService", new { id = tenantService.ID }, tenantService);
        }

        // DELETE: api/TenantServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenantService(int id)
        {
            var tenantService = await _context.TenantServices.FindAsync(id);
            if (tenantService == null)
            {
                return NotFound();
            }

            _context.TenantServices.Remove(tenantService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TenantServiceExists(int id)
        {
            return _context.TenantServices.Any(e => e.ID == id);
        }
    }
}
