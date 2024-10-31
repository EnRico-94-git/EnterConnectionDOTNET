using AdvancedBusinessDev.Models;
using AdvancedBusinessDev.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Services
{
    public class EmpresaService
    {
        private readonly IGenericRepository<Empresa> _empresaRepository;

        public EmpresaService(IGenericRepository<Empresa> empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
        {
            return await _empresaRepository.GetAllAsync();
        }

        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            return await _empresaRepository.GetByIdAsync(id);
        }

        public async Task AddEmpresaAsync(Empresa empresa)
        {
            await _empresaRepository.AddAsync(empresa);
        }

        public async Task UpdateEmpresaAsync(Empresa empresa)
        {
            await _empresaRepository.UpdateAsync(empresa);
        }

        public async Task DeleteEmpresaAsync(int id)
        {
            await _empresaRepository.DeleteAsync(id);
        }
    }
}
