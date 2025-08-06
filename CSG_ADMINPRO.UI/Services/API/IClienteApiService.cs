using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.DOMAIN.Entities;

namespace CSG_ADMINPRO.UI.Services.API
{
    public interface IClienteApiService
    {
        Task<IEnumerable<Cliente>> ObtenerClienteAsync();
        Task<Cliente> BuscarClienteIdAsync(int id);
        Task<(bool Success, string Message)> CreateClienteAsync(ClienteDTO cliente);
        Task<(bool Success, string Message)> UpdateClienteAsync(int id, ClienteDTO cliente);
        Task<(bool Success, string Message)> DeleteClienteAsync(int id);

    }
}
