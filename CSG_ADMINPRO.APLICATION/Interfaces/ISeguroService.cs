using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Interfaces
{
    public interface ISeguroService
    {
        Task<IEnumerable<Seguro>> GetAllSegurosAsync();
        Task<Seguro> GetSeguroByIdAsync(int id);
        Task CreateSeguroAsync(Seguro seguro);
        Task UpdateSeguroAsync(int id, Seguro seguro);
        Task DeleteSeguroAsync(int id);
    }
}
