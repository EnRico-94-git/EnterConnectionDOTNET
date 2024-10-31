using AdvancedBusinessDev.DataBase;
using AdvancedBusinessDev.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Repositories
{
    public class ParceiroRepository : IGenericRepository<Parceiro>
    {
        private readonly ABDcontext _context;

        public ParceiroRepository(ABDcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parceiro>> GetAllAsync()
        {
            return await _context.Parceiros.ToListAsync();
        }

        public async Task<Parceiro> GetByIdAsync(int id)
        {
            return await _context.Parceiros.FindAsync(id);
        }

        public async Task AddAsync(Parceiro parceiro)
        {
            await _context.Parceiros.AddAsync(parceiro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parceiro parceiro)
        {
            _context.Parceiros.Update(parceiro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parceiro = await GetByIdAsync(id);
            if (parceiro != null)
            {
                _context.Parceiros.Remove(parceiro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
