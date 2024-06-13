using CSG_ADMINPRO.APLICATION.ViewModel;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Interfaces
{
    public interface ICitaService
    {
        Task<IEnumerable<CitaDTO>> GetAllCitaAsync();
        Task<Cita> GetByIdAsync(int id);
        Task CreateCitaAsync(CitaCreateDTO cita);
        Task UpdateCitaAsync(int id, CitaUpdateDTO cita);
        Task DeleteCitaAsync(int id);
    }
}
