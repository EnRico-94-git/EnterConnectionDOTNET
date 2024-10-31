using AdvancedBusinessDev.Models;
using AdvancedBusinessDev.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Services
{
    public class IAService
    {
        private readonly IGenericRepository<IA> _iaRepository;

        public IAService(IGenericRepository<IA> iaRepository)
        {
            _iaRepository = iaRepository;
        }

        public async Task<IEnumerable<IA>> GetAllIAsAsync()
        {
            return await _iaRepository.GetAllAsync();
        }

        public async Task<IA> GetIAByIdAsync(int id)
        {
            return await _iaRepository.GetByIdAsync(id);
        }

        public async Task AddIAAsync(IA ia)
        {
            await _iaRepository.AddAsync(ia);
        }

        public async Task UpdateIAAsync(IA ia)
        {
            await _iaRepository.UpdateAsync(ia);
        }

        public async Task DeleteIAAsync(int id)
        {
            await _iaRepository.DeleteAsync(id);
        }
    }
}
