using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;

namespace DinExApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchesController : ControllerBase
    {
        private readonly DinExApiContext _context;

        public LaunchesController(DinExApiContext context)
        {
            _context = context;
        }

        // GET: api/Launches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Launch>>> GetLaunch()
        {
            return await _context.Launch.ToListAsync();
        }

        // GET: api/Launches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Launch>> GetLaunch(int id)
        {
            var launch = await _context.Launch.FindAsync(id);

            if (launch == null)
            {
                return NotFound();
            }

            return launch;
        }

        // PUT: api/Launches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaunch(int id, Launch launch)
        {
            if (id != launch.Id)
            {
                return BadRequest();
            }

            _context.Entry(launch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaunchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Launches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Launch>> PostLaunch(Launch launch)
        {
            _context.Launch.Add(launch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaunch", new { id = launch.Id }, launch);
        }

        // DELETE: api/Launches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaunch(int id)
        {
            var launch = await _context.Launch.FindAsync(id);
            if (launch == null)
            {
                return NotFound();
            }

            _context.Launch.Remove(launch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LaunchExists(int id)
        {
            return _context.Launch.Any(e => e.Id == id);
        }
    }
}
