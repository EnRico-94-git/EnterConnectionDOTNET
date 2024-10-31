using AdvancedBusinessDev.DataBase;
using AdvancedBusinessDev.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Repositories
{
    public class EmpresaRepository : IGenericRepository<Empresa>
    {
        private readonly ABDcontext _context;

        public EmpresaRepository(ABDcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa> GetByIdAsync(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public async Task AddAsync(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empresa = await GetByIdAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
