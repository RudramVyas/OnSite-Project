using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSite.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnSite.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSheetController : ControllerBase
    {
        private readonly OnSiteDbContext _context;
        public TimeSheetController(OnSiteDbContext context)
        {
            _context = context;
        }

        // GET: api/TimeSheet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheet>>> GetTimeSheets()
        {
            return await _context.TimeSheet.ToListAsync();
        }

        // GET: api/TimeSheet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheet>> GetTimeSheet(int id)
        {
            var timeSheet = await _context.TimeSheet.FindAsync(id);
            if (timeSheet == null)
                return NotFound();
            return timeSheet;
        }

        // POST: api/TimeSheet
        [HttpPost]
        public async Task<ActionResult<TimeSheet>> CreateTimeSheet([FromBody] TimeSheet timeSheet)
        {
            _context.TimeSheet.Add(timeSheet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTimeSheet), new { id = timeSheet.TimeSheetId }, timeSheet);
        }

        // PUT: api/TimeSheet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSheet(int id, TimeSheet timeSheet)
        {
            if (id != timeSheet.TimeSheetId)
                return BadRequest();
            _context.Entry(timeSheet).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.TimeSheet.AnyAsync(t => t.TimeSheetId == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/TimeSheet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSheet(int id)
        {
            var timeSheet = await _context.TimeSheet.FindAsync(id);
            if (timeSheet == null)
                return NotFound();
            _context.TimeSheet.Remove(timeSheet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
