using Microsoft.AspNetCore.Mvc;
using OnSite.Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnSite.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly OnSiteDbContext _context;

        public TestController(OnSiteDbContext context)
        {
            _context = context;
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {
            try
            {
                var events = await _context.Event.ToListAsync();
                return Ok(events);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
