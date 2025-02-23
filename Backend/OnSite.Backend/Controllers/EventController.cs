using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSite.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnSite.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly OnSiteDbContext _context;

        public EventController(OnSiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Event
        // Calls sp_GetAllEvents to retrieve all events.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var events = await _context.Event
                .FromSqlRaw("EXEC sp_GetAllEvents")
                .ToListAsync();
            return Ok(events);
        }

        // GET: api/Event/5
        // Calls sp_GetEventById to retrieve a single event by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var evt = await _context.Event
                .FromSqlInterpolated($"EXEC sp_GetEventById @EventId={id}")
                .FirstOrDefaultAsync();
            if (evt == null)
                return NotFound();
            return evt;
        }

        // POST: api/Event
        // Calls sp_CreateEvent to create a new event.
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(Event evt)
        {
            // The stored procedure should insert a new event and return the new ID.
            var result = await _context.Event
                .FromSqlInterpolated($"EXEC sp_CreateEvent @Name={evt.Name}, @EventDate={evt.EventDate}, @Location={evt.Location}, @QuoteDetails={evt.QuoteDetails}")
                .ToListAsync();

            if (result.Count > 0)
            {
                int newId = result[0].EventId;
                return CreatedAtAction(nameof(GetEvent), new { id = newId }, result[0]);
            }
            else
            {
                return BadRequest("Unable to create event.");
            }
        }

        // PUT: api/Event/5
        // Calls sp_UpdateEvent to update an existing event.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event evt)
        {
            if (id != evt.EventId)
                return BadRequest();

            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_UpdateEvent @EventId={id}, @Name={evt.Name}, @EventDate={evt.EventDate}, @Location={evt.Location}, @QuoteDetails={evt.QuoteDetails}");

            return NoContent();
        }

        // DELETE: api/Event/5
        // Calls sp_DeleteEvent to delete an event.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_DeleteEvent @EventId={id}");
            return NoContent();
        }
    }
}
