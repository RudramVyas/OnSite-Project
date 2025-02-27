using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSite.Backend.Models;
using System.Collections.Generic;
using System.Linq;
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
            return await _context.Assignment.ToListAsync();
        }

        // GET: api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
                return NotFound();
            return assignment;
        }

        // POST: api/Assignment
        [HttpPost]
        public async Task<ActionResult<Assignment>> CreateAssignment([FromBody] Assignment assignment)
        {
            // Business rules:dot
            if (assignment.AssignedRole == "L2 Supervisor")
            {
                // EventId must not be in Assignment
                var l2SupervisorExists = await _context.Assignment
                    .AnyAsync(a => a.EventId == assignment.EventId);
                if (l2SupervisorExists)
                    return BadRequest("L2 Supervisor already exists.");

                // L2 must be assigned to an event (SubEventId must be null)
                if (assignment.SubEventId != null)
                    return BadRequest("For L2 Supervisor assignments, SubEventId must be null.");
            }
            else if (assignment.AssignedRole == "L1 Supervisor")
            {
                // L1 must be assigned to a sub-event (SubEventId required)
                var subEventExists = await _context.Assignment
                    .AnyAsync(a => a.SubEventId == assignment.SubEventId);
                if (subEventExists)
                    return BadRequest("Sub Event already assigned to someone.");
                if (assignment.SubEventId == null || assignment.SubEventId <= 0)
                    return BadRequest("For L1 Supervisor assignments, SubEventId is required.");
            }
            else if (assignment.AssignedRole == "Laborer")
            {
                // Laborer assignment must verify availability
                var laborer = await _context.Laborer.FindAsync(assignment.LaborerId);
                if (laborer == null)
                    return BadRequest("Invalid LaborerId.");
                if (!laborer.IsAvailable)
                    return BadRequest("Laborer is not available.");

                // Mark laborer as unavailable
                laborer.IsAvailable = false;
                _context.Entry(laborer).State = EntityState.Modified;
            }

            _context.Assignment.Add(assignment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssignment), new { id = assignment.AssignmentId }, assignment);
        }

        // PUT: api/Assignment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentId)
                return BadRequest();

            _context.Entry(assignment).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Assignment.AnyAsync(a => a.AssignmentId == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Assignment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
                return NotFound();
            _context.Assignment.Remove(assignment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
