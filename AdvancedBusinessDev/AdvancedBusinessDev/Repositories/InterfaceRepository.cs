using AdvancedBusinessDev.DataBase;
using AdvancedBusinessDev.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Repositories
{
    public class InterfaceRepository : IGenericRepository<Interface>
    {
        private readonly ABDcontext _context;

        public InterfaceRepository(ABDcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interface>> GetAllAsync()
        {
            return await _context.Interfaces.ToListAsync();
        }

        public async Task<Interface> GetByIdAsync(int id)
        {
            return await _context.Interfaces.FindAsync(id);
        }

        public async Task AddAsync(Interface @interface)
        {
            await _context.Interfaces.AddAsync(@interface);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Interface @interface)
        {
            _context.Interfaces.Update(@interface);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var @interface = await GetByIdAsync(id);
            if (@interface != null)
            {
                _context.Interfaces.Remove(@interface);
                await _context.SaveChangesAsync();
            }
        }
    }
}
