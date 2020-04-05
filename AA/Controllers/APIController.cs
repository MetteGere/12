using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AA.Data;
using AA.Models;

namespace AA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bil>>> GetBil()
        {
            return await _context.Bil.ToListAsync();
        }

        // GET: api/API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bil>> GetBil(int id)
        {
            var bil = await _context.Bil.FindAsync(id);

            if (bil == null)
            {
                return NotFound();
            }

            return bil;
        }

        // PUT: api/API/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBil(int id, Bil bil)
        {
            if (id != bil.ID)
            {
                return BadRequest();
            }

            _context.Entry(bil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilExists(id))
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

        // POST: api/API
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bil>> PostBil(Bil bil)
        {
            _context.Bil.Add(bil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBil", new { id = bil.ID }, bil);
        }

        // DELETE: api/API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bil>> DeleteBil(int id)
        {
            var bil = await _context.Bil.FindAsync(id);
            if (bil == null)
            {
                return NotFound();
            }

            _context.Bil.Remove(bil);
            await _context.SaveChangesAsync();

            return bil;
        }

        private bool BilExists(int id)
        {
            return _context.Bil.Any(e => e.ID == id);
        }
    }
}
