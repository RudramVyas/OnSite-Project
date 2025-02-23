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
            var timesheets = await _context.TimeSheet
                .FromSqlRaw("EXEC sp_GetAllTimeSheets")
                .ToListAsync();
            return Ok(timesheets);
        }

        // GET: api/TimeSheet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheet>> GetTimeSheet(int id)
        {
            var timesheet = await _context.TimeSheet
                .FromSqlInterpolated($"EXEC sp_GetTimeSheetById @TimeSheetId={id}")
                .FirstOrDefaultAsync();
            if (timesheet == null)
                return NotFound();
            return timesheet;
        }

        // POST: api/TimeSheet
        [HttpPost]
        public async Task<ActionResult<TimeSheet>> CreateTimeSheet(TimeSheet timesheet)
        {
            var result = await _context.TimeSheet
                .FromSqlInterpolated($"EXEC sp_CreateTimeSheet @AssignmentId={timesheet.AssignmentId}, @HoursWorked={timesheet.HoursWorked}, @WorkDate={timesheet.WorkDate}")
                .ToListAsync();

            if (result.Count > 0)
            {
                int newId = result[0].TimeSheetId;
                return CreatedAtAction(nameof(GetTimeSheet), new { id = newId }, result[0]);
            }
            else
            {
                return BadRequest("Unable to create timesheet.");
            }
        }

        // PUT: api/TimeSheet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSheet(int id, TimeSheet timesheet)
        {
            if (id != timesheet.TimeSheetId)
                return BadRequest();

            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_UpdateTimeSheet @TimeSheetId={id}, @AssignmentId={timesheet.AssignmentId}, @HoursWorked={timesheet.HoursWorked}, @WorkDate={timesheet.WorkDate}");
            return NoContent();
        }

        // DELETE: api/TimeSheet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSheet(int id)
        {
            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_DeleteTimeSheet @TimeSheetId={id}");
            return NoContent();
        }
    }
}
