using AdvancedBusinessDev.Models;
using AdvancedBusinessDev.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedBusinessDev.Services
{
    public class ClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public ClienteService(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
    }
}
