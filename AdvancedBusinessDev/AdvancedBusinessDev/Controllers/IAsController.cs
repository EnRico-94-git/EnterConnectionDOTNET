using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvancedBusinessDev.DataBase;
using AdvancedBusinessDev.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IAsController : ControllerBase
    {
        private readonly ABDcontext _context;

        public IAsController(ABDcontext context)
        {
            _context = context;
        }

        // GET: api/IAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IA>>> GetIAs()
        {
            return await _context.IAs.ToListAsync();
        }

        // GET: api/IAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IA>> GetIA(int id)
        {
            var ia = await _context.IAs.FindAsync(id);

            if (ia == null)
            {
                return NotFound();
            }

            return ia;
        }

        // POST: api/IAs
        [HttpPost]
        public async Task<ActionResult<IA>> PostIA(IA ia)
        {
            _context.IAs.Add(ia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIA), new { id = ia.IdIa }, ia);
        }

        // PUT: api/IAs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIA(int id, IA ia)
        {
            if (id != ia.IdIa)
            {
                return BadRequest();
            }

            _context.Entry(ia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IAExists(id))
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

        // DELETE: api/IAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIA(int id)
        {
            var ia = await _context.IAs.FindAsync(id);
            if (ia == null)
            {
                return NotFound();
            }

            _context.IAs.Remove(ia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IAExists(int id)
        {
            return _context.IAs.Any(e => e.IdIa == id);
        }
    }
}
