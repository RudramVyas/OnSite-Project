using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSite.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnSite.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly OnSiteDbContext _context;

        public AssignmentController(OnSiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Assignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            var assignments = await _context.Assignment
                .FromSqlRaw("EXEC sp_GetAllAssignments")
                .ToListAsync();
            return Ok(assignments);
        }

        // GET: api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            var assignment = await _context.Assignment
                .FromSqlInterpolated($"EXEC sp_GetAssignmentById @AssignmentId={id}")
                .FirstOrDefaultAsync();
            if (assignment == null)
                return NotFound();
            return assignment;
        }

        // POST: api/Assignment
        [HttpPost]
        public async Task<ActionResult<Assignment>> CreateAssignment(Assignment assignment)
        {
            var result = await _context.Assignment
                .FromSqlInterpolated($"EXEC sp_CreateAssignment @EventId={assignment.EventId}, @SubEventId={assignment.SubEventId}, @SupervisorId={assignment.SupervisorId}, @LaborerId={assignment.LaborerId}, @AssignedRole={assignment.AssignedRole}")
                .ToListAsync();

            if (result.Count > 0)
            {
                int newId = result[0].AssignmentId;
                return CreatedAtAction(nameof(GetAssignment), new { id = newId }, result[0]);
            }
            else
            {
                return BadRequest("Unable to create assignment.");
            }
        }

        // PUT: api/Assignment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentId)
                return BadRequest();

            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_UpdateAssignment @AssignmentId={id}, @EventId={assignment.EventId}, @SubEventId={assignment.SubEventId}, @SupervisorId={assignment.SupervisorId}, @LaborerId={assignment.LaborerId}, @AssignedRole={assignment.AssignedRole}");
            return NoContent();
        }

        // DELETE: api/Assignment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_DeleteAssignment @AssignmentId={id}");
            return NoContent();
        }
    }
}
