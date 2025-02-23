using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSite.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnSite.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubEventController : ControllerBase
    {
        private readonly OnSiteDbContext _context;

        public SubEventController(OnSiteDbContext context)
        {
            _context = context;
        }

        // GET: api/SubEvent
        // Calls sp_GetAllSubEvents to retrieve all sub-events.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubEvent>>> GetSubEvents()
        {
            var subEvents = await _context.SubEvents
                .FromSqlRaw("EXEC sp_GetAllSubEvents")
                .ToListAsync();
            return Ok(subEvents);
        }

        // GET: api/SubEvent/5
        // Calls sp_GetSubEventById to retrieve a single sub-event.
        [HttpGet("{id}")]
        public async Task<ActionResult<SubEvent>> GetSubEvent(int id)
        {
            var subEvt = await _context.SubEvents
                .FromSqlInterpolated($"EXEC sp_GetSubEventById @SubEventId={id}")
                .FirstOrDefaultAsync();
            if (subEvt == null)
                return NotFound();
            return subEvt;
        }

        // POST: api/SubEvent
        // Calls sp_CreateSubEvent to insert a new sub-event.
        [HttpPost]
        public async Task<ActionResult<SubEvent>> CreateSubEvent(SubEvent subEvt)
        {
            var result = await _context.SubEvents
                .FromSqlInterpolated($"EXEC sp_CreateSubEvent @EventId={subEvt.EventId}, @Name={subEvt.Name}, @Description={subEvt.Description}")
                .ToListAsync();
            if (result.Count > 0)
            {
                int newId = result[0].SubEventId;
                return CreatedAtAction(nameof(GetSubEvent), new { id = newId }, result[0]);
            }
            else
            {
                return BadRequest("Unable to create sub-event.");
            }
        }

        // PUT: api/SubEvent/5
        // Calls sp_UpdateSubEvent to update an existing sub-event.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubEvent(int id, SubEvent subEvt)
        {
            if (id != subEvt.SubEventId)
                return BadRequest();

            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_UpdateSubEvent @SubEventId={id}, @EventId={subEvt.EventId}, @Name={subEvt.Name}, @Description={subEvt.Description}");
            return NoContent();
        }

        // DELETE: api/SubEvent/5
        // Calls sp_DeleteSubEvent to remove a sub-event.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubEvent(int id)
        {
            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_DeleteSubEvent @SubEventId={id}");
            return NoContent();
        }
    }
}
