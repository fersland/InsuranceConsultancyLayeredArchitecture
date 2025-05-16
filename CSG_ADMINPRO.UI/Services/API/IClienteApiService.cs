using CSG_ADMINPRO.DOMAIN.Entities;

namespace CSG_ADMINPRO.UI.Services.API
{
    public interface IClienteApiService
    {
        Task<IEnumerable<Cliente>> ObtenerClienteAsync();
    }
}
