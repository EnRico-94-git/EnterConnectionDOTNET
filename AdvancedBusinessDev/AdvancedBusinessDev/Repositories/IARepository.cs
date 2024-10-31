using AdvancedBusinessDev.DataBase;
using AdvancedBusinessDev.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Repositories
{
    public class IARepository : IGenericRepository<IA>
    {
        private readonly ABDcontext _context;

        public IARepository(ABDcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IA>> GetAllAsync()
        {
            return await _context.IAs.ToListAsync();
        }

        public async Task<IA> GetByIdAsync(int id)
        {
            return await _context.IAs.FindAsync(id);
        }

        public async Task AddAsync(IA ia)
        {
            await _context.IAs.AddAsync(ia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IA ia)
        {
            _context.IAs.Update(ia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ia = await GetByIdAsync(id);
            if (ia != null)
            {
                _context.IAs.Remove(ia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
