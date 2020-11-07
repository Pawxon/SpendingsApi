using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendingsApi.Data;
using SpendingsApi.Models;

namespace SpendingsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpendingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Spendings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spendings>>> GetSpendings()
        {
            return await _context.Spendings.ToListAsync();
        }

        // GET: api/Spendings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spendings>> GetSpendings(int id)
        {
            var spendings = await _context.Spendings.FindAsync(id);

            if (spendings == null)
            {
                return NotFound();
            }

            return spendings;
        }

        // PUT: api/Spendings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpendings(int id, Spendings spendings)
        {
            if (id != spendings.idSpendings)
            {
                return BadRequest();
            }

            _context.Entry(spendings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpendingsExists(id))
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

        // POST: api/Spendings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Spendings>> PostSpendings(Spendings spendings)
        {
            _context.Spendings.Add(spendings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpendings", new { id = spendings.idSpendings }, spendings);
        }

        // DELETE: api/Spendings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spendings>> DeleteSpendings(int id)
        {
            var spendings = await _context.Spendings.FindAsync(id);
            if (spendings == null)
            {
                return NotFound();
            }

            _context.Spendings.Remove(spendings);
            await _context.SaveChangesAsync();

            return spendings;
        }

        private bool SpendingsExists(int id)
        {
            return _context.Spendings.Any(e => e.idSpendings == id);
        }
    }
}
