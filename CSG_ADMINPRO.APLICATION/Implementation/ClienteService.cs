using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.APLICATION.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Implementation
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;    
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await Task.Run(() => _clienteRepository.GetAll());
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await Task.Run(() => _clienteRepository.GetById(id));
        }

        public async Task CreateClienteAsync(Cliente cliente)
        {
            await Task.Run(() => _clienteRepository.Insert(cliente));
        }

        public async Task UpdateClienteAsync(int id, Cliente cliente)
        {
            await Task.Run(() => _clienteRepository.Update(id, cliente));
        }

        public async Task DeleteClienteAsync(int id)
        {
            await Task.Run(() => _clienteRepository.Delete(id));
        }
    }
}
