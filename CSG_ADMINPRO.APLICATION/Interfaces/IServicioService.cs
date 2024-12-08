using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Interfaces
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicio>> GetAllServicioAsync();
        Task<Servicio> GetByIdAsync(int id);
        Task CreateServicioAsync(Servicio servicio);
        Task UpdateServicioAsync(int id, Servicio servicio);
        Task DeleteServicioAsync(int id);
    }
}
