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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubEvent>>> GetSubEvents()
        {
            return await _context.SubEvents.ToListAsync();
        }

        // GET: api/SubEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubEvent>> GetSubEvent(int id)
        {
            var subEvent = await _context.SubEvents.FindAsync(id);
            if (subEvent == null)
                return NotFound();
            return subEvent;
        }

        // POST: api/SubEvent
        [HttpPost]
        public async Task<ActionResult<SubEvent>> CreateSubEvent(SubEvent subEvent)
        {
            // Business rule: SubEvent must have a valid EventId.
            if (subEvent.EventId <= 0)
                return BadRequest("SubEvent must be associated with a valid Event.");

            _context.SubEvents.Add(subEvent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSubEvent), new { id = subEvent.SubEventId }, subEvent);
        }

        // PUT: api/SubEvent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubEvent(int id, SubEvent subEvent)
        {
            if (id != subEvent.SubEventId)
                return BadRequest();

            _context.Entry(subEvent).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.SubEvents.AnyAsync(e => e.SubEventId == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/SubEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubEvent(int id)
        {
            var subEvent = await _context.SubEvents.FindAsync(id);
            if (subEvent == null)
                return NotFound();

            _context.SubEvents.Remove(subEvent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
