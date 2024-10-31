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
    public class InterfacesController : ControllerBase
    {
        private readonly ABDcontext _context;

        public InterfacesController(ABDcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interface>>> GetInterfaces()
        {
            return await _context.Interfaces.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Interface>> GetInterface(int id)
        {
            var @interface = await _context.Interfaces.FindAsync(id);
            if (@interface == null)
            {
                return NotFound();
            }
            return @interface;
        }

        [HttpPost]
        public async Task<ActionResult<Interface>> PostInterface(Interface @interface)
        {
            _context.Interfaces.Add(@interface);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInterface), new { id = @interface.IdInterface }, @interface);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterface(int id, Interface @interface)
        {
            if (id != @interface.IdInterface)
            {
                return BadRequest();
            }
            _context.Entry(@interface).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterface(int id)
        {
            var @interface = await _context.Interfaces.FindAsync(id);
            if (@interface == null)
            {
                return NotFound();
            }
            _context.Interfaces.Remove(@interface);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
