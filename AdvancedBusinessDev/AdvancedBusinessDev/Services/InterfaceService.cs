using AdvancedBusinessDev.Models;
using AdvancedBusinessDev.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Services
{
    public class InterfaceService
    {
        private readonly IGenericRepository<Interface> _interfaceRepository;

        public InterfaceService(IGenericRepository<Interface> interfaceRepository)
        {
            _interfaceRepository = interfaceRepository;
        }

        public async Task<IEnumerable<Interface>> GetAllInterfacesAsync()
        {
            return await _interfaceRepository.GetAllAsync();
        }

        public async Task<Interface> GetInterfaceByIdAsync(int id)
        {
            return await _interfaceRepository.GetByIdAsync(id);
        }

        public async Task AddInterfaceAsync(Interface @interface)
        {
            await _interfaceRepository.AddAsync(@interface);
        }

        public async Task UpdateInterfaceAsync(Interface @interface)
        {
            await _interfaceRepository.UpdateAsync(@interface);
        }

        public async Task DeleteInterfaceAsync(int id)
        {
            await _interfaceRepository.DeleteAsync(id);
        }
    }
}
