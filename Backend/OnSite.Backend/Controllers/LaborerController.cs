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
            return await _context.Laborer.ToListAsync();
        }

        // GET: api/Laborer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laborer>> GetLaborer(int id)
        {
            var laborer = await _context.Laborer.FindAsync(id);
            if (laborer == null)
                return NotFound();
            return laborer;
        }

        // POST: api/Laborer
        [HttpPost]
        public async Task<ActionResult<Laborer>> CreateLaborer([FromBody] Laborer laborer)
        {
            _context.Laborer.Add(laborer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLaborer), new { id = laborer.LaborerId }, laborer);
        }

        // PUT: api/Laborer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLaborer(int id, Laborer laborer)
        {
            if (id != laborer.LaborerId)
                return BadRequest();

            _context.Entry(laborer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Laborer.AnyAsync(l => l.LaborerId == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Laborer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaborer(int id)
        {
            var laborer = await _context.Laborer.FindAsync(id);
            if (laborer == null)
                return NotFound();

            _context.Laborer.Remove(laborer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
