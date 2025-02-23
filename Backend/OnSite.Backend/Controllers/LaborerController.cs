using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSite.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnSite.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaborerController : ControllerBase
    {
        private readonly OnSiteDbContext _context;

        public LaborerController(OnSiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Laborer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laborer>>> GetLaborers()
        {
            var laborers = await _context.Laborer
                .FromSqlRaw("EXEC sp_GetAllLaborers")
                .ToListAsync();
            return Ok(laborers);
        }

        // GET: api/Laborer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laborer>> GetLaborer(int id)
        {
            var laborer = await _context.Laborer
                .FromSqlInterpolated($"EXEC sp_GetLaborerById @LaborerId={id}")
                .FirstOrDefaultAsync();
            if (laborer == null)
                return NotFound();
            return laborer;
        }

        // POST: api/Laborer
        [HttpPost]
        public async Task<ActionResult<Laborer>> CreateLaborer(Laborer laborer)
        {
            var result = await _context.Laborer
                .FromSqlInterpolated($"EXEC sp_CreateLaborer @Name={laborer.Name}, @IsAvailable={laborer.IsAvailable}")
                .ToListAsync();

            if (result.Count > 0)
            {
                int newId = result[0].LaborerId;
                return CreatedAtAction(nameof(GetLaborer), new { id = newId }, result[0]);
            }
            else
            {
                return BadRequest("Unable to create laborer.");
            }
        }

        // PUT: api/Laborer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLaborer(int id, Laborer laborer)
        {
            if (id != laborer.LaborerId)
                return BadRequest();

            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_UpdateLaborer @LaborerId={id}, @Name={laborer.Name}, @IsAvailable={laborer.IsAvailable}");
            return NoContent();
        }

        // DELETE: api/Laborer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaborer(int id)
        {
            int affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_DeleteLaborer @LaborerId={id}");
            return NoContent();
        }
    }
}
