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
            var supervisors = await _context.Supervisor
                .FromSqlRaw("EXEC sp_GetAllSupervisors")
                .ToListAsync();
            return Ok(supervisors);
        }

        // GET: api/Supervisor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supervisor>> GetSupervisor(int id)
        {
            var supervisor = await _context.Supervisor
                .FromSqlInterpolated($"EXEC sp_GetSupervisorById @SupervisorId={id}")
                .FirstOrDefaultAsync();
            if (supervisor == null)
                return NotFound();
            return supervisor;
        }

        // POST: api/Supervisor
        [HttpPost]
        public async Task<ActionResult<Supervisor>> CreateSupervisor(Supervisor supervisor)
        {
            var result = await _context.Supervisor
                .FromSqlInterpolated($"EXEC sp_CreateSupervisor @Name={supervisor.Name}, @Level={supervisor.Level}")
                .ToListAsync();

            if (result.Count > 0)
            {
                int newId = result[0].SupervisorId;
                return CreatedAtAction(nameof(GetSupervisor), new { id = newId }, result[0]);
            }
            else
            {
                return BadRequest("Unable to create supervisor.");
            }
        }

        // PUT: api/Supervisor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupervisor(int id, Supervisor supervisor)
        {
            if (id != supervisor.SupervisorId)
                return BadRequest();

            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_UpdateSupervisor @SupervisorId={id}, @Name={supervisor.Name}, @Level={supervisor.Level}");
            return NoContent();
        }

        // DELETE: api/Supervisor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupervisor(int id)
        {
            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_DeleteSupervisor @SupervisorId={id}");
            return NoContent();
        }
    }
}
