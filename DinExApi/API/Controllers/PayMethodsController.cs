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
    public class PayMethodsController : ControllerBase
    {
        private readonly DinExApiContext _context;

        public PayMethodsController(DinExApiContext context)
        {
            _context = context;
        }

        // GET: api/PayMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayMethod>>> GetPayMethod()
        {
            return await _context.PayMethod.ToListAsync();
        }

        // GET: api/PayMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayMethod>> GetPayMethod(int id)
        {
            var payMethod = await _context.PayMethod.FindAsync(id);

            if (payMethod == null)
            {
                return NotFound();
            }

            return payMethod;
        }

        // PUT: api/PayMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayMethod(int id, PayMethod payMethod)
        {
            if (id != payMethod.Id)
            {
                return BadRequest();
            }

            _context.Entry(payMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayMethodExists(id))
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

        // POST: api/PayMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayMethod>> PostPayMethod(PayMethod payMethod)
        {
            _context.PayMethod.Add(payMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayMethod", new { id = payMethod.Id }, payMethod);
        }

        // DELETE: api/PayMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayMethod(int id)
        {
            var payMethod = await _context.PayMethod.FindAsync(id);
            if (payMethod == null)
            {
                return NotFound();
            }

            _context.PayMethod.Remove(payMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayMethodExists(int id)
        {
            return _context.PayMethod.Any(e => e.Id == id);
        }
    }
}
