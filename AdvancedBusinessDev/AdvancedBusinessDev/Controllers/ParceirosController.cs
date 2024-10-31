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
    public class ParceirosController : ControllerBase
    {
        private readonly ABDcontext _context;

        public ParceirosController(ABDcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parceiro>>> GetParceiros()
        {
            return await _context.Parceiros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parceiro>> GetParceiro(int id)
        {
            var parceiro = await _context.Parceiros.FindAsync(id);
            if (parceiro == null)
            {
                return NotFound();
            }
            return parceiro;
        }

        [HttpPost]
        public async Task<ActionResult<Parceiro>> PostParceiro(Parceiro parceiro)
        {
            _context.Parceiros.Add(parceiro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParceiro), new { id = parceiro.IdParceiro }, parceiro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParceiro(int id, Parceiro parceiro)
        {
            if (id != parceiro.IdParceiro)
            {
                return BadRequest();
            }
            _context.Entry(parceiro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParceiro(int id)
        {
            var parceiro = await _context.Parceiros.FindAsync(id);
            if (parceiro == null)
            {
                return NotFound();
            }
            _context.Parceiros.Remove(parceiro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
