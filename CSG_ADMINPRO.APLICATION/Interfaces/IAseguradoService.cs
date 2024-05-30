using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Interfaces
{
    public interface IAseguradoService
    {
        Task<IEnumerable<AseguradosDTO>> GetAllAseguradosAsync();
        Task<Asegurado> GetByIdAseguradoAsync(int id);
        Task CreateAseguradoAsync(Asegurado asegurado);
        Task UpdateAseguradoAsync(int id, Asegurado asegurado);
        Task DeleteAseguradoAsync(int id);
    }
}
