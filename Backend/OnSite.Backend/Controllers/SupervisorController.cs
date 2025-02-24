using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSite.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnSite.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupervisorController : ControllerBase
    {
        private readonly OnSiteDbContext _context;

        public SupervisorController(OnSiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Supervisor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supervisor>>> GetSupervisors()
        {
            return await _context.Supervisor.ToListAsync();
        }

        // GET: api/Supervisor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supervisor>> GetSupervisor(int id)
        {
            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor == null)
                return NotFound();
            return supervisor;
        }

        // POST: api/Supervisor
        [HttpPost]
        public async Task<ActionResult<Supervisor>> CreateSupervisor([FromBody] Supervisor supervisor)
        {
            // Allow creation without assignments.
            _context.Supervisor.Add(supervisor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSupervisor), new { id = supervisor.SupervisorId }, supervisor);
        }

        // PUT: api/Supervisor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupervisor(int id, Supervisor supervisor)
        {
            if (id != supervisor.SupervisorId)
                return BadRequest();

            _context.Entry(supervisor).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Supervisor.AnyAsync(s => s.SupervisorId == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Supervisor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupervisor(int id)
        {
            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor == null)
                return NotFound();

            _context.Supervisor.Remove(supervisor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
