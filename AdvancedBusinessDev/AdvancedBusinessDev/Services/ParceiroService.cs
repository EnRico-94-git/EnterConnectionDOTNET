using AdvancedBusinessDev.Models;
using AdvancedBusinessDev.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Services
{
    public class ParceiroService
    {
        private readonly IGenericRepository<Parceiro> _parceiroRepository;

        public ParceiroService(IGenericRepository<Parceiro> parceiroRepository)
        {
            _parceiroRepository = parceiroRepository;
        }

        public async Task<IEnumerable<Parceiro>> GetAllParceirosAsync()
        {
            return await _parceiroRepository.GetAllAsync();
        }

        public async Task<Parceiro> GetParceiroByIdAsync(int id)
        {
            return await _parceiroRepository.GetByIdAsync(id);
        }

        public async Task AddParceiroAsync(Parceiro parceiro)
        {
            await _parceiroRepository.AddAsync(parceiro);
        }

        public async Task UpdateParceiroAsync(Parceiro parceiro)
        {
            await _parceiroRepository.UpdateAsync(parceiro);
        }

        public async Task DeleteParceiroAsync(int id)
        {
            await _parceiroRepository.DeleteAsync(id);
        }
    }
}
